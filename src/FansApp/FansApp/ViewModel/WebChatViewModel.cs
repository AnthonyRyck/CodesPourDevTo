using FansApp.Models;
using HeyRed.MarkdownSharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using FansApp.Services;

namespace FansApp.ViewModel
{
	public class WebChatViewModel : IWebChatViewModel
	{
		/// <see cref="IWebChatViewModel.TousLesMessages"/>
		public List<Message> TousLesMessages { get; set; }

		/// <see cref="IWebChatViewModel.LastMessageJson"/>
		public string LastMessageJson { get; private set; }

		private InfoVariablesEnvironment VariablesEnvironment;

		public string Question { get; set; }

		public Markdown Markdown { get; private set; }


		public string UrlIframeWebBot { get; private set; }


		public bool HaveServiceQnAMaker { get; private set; }

		public WebChatViewModel(InfoVariablesEnvironment variablesEnvironment)
		{
			var options = new MarkdownOptions
			{
				AutoHyperlink = true,
				LinkEmails = true,
				QuoteSingleLine = true,
				StrictBoldItalic = true,
				DisableEncodeCodeBlock = true,
				AutoNewLines = true
			};

			Markdown = new Markdown(options);

			TousLesMessages = new List<Message>();
			VariablesEnvironment = variablesEnvironment;

			if(!string.IsNullOrEmpty(variablesEnvironment.QnaIdApp)
				&& !string.IsNullOrEmpty(variablesEnvironment.QnaMakerEndPoint)
				&& !string.IsNullOrEmpty(variablesEnvironment.QnaMakerKey))
			{
				HaveServiceQnAMaker = true;
			}
		}


		/// <see cref="IWebChatViewModel.GetClass(bool)"/>
		public string GetClass(bool isQuestion)
		{
			return isQuestion
				? "cardquestion"
				: "cardanswer";
		}

		/// <see cref="IWebChatViewModel.GetAlign(bool)"/>
		public string GetAlign(bool isQuestion)
		{
			return isQuestion
				? "left"
				: "right";
		}



		public async Task PoserLaQuestion(string question)
		{
			Message questionMsg = new Message();
			questionMsg.IsQuestion = true;
			questionMsg.TexteMessage = question;
			TousLesMessages.Add(questionMsg);

			string urlQnA = $"https://{VariablesEnvironment.QnaMakerEndPoint}.azurewebsites.net/qnamaker/knowledgebases/{VariablesEnvironment.QnaIdApp}/generateAnswer";

			HttpWebRequest httpWebRequest = WebRequest.CreateHttp(urlQnA);
			httpWebRequest.ContentType = "application/json";
			httpWebRequest.Method = "POST";
			httpWebRequest.Headers.Add("Authorization", $"EndpointKey {VariablesEnvironment.QnaMakerKey} "); 

			using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
			{
				string json = "{ \"question\" :\"" + question + "\"}";

				streamWriter.Write(json);
				streamWriter.Flush();
			}
			try
			{
				var httpResponse = (HttpWebResponse)(await httpWebRequest.GetResponseAsync());

				using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
				{
					string json = await streamReader.ReadToEndAsync();
					// Convertion en Message
					ConvertToMessage(json);
					LastMessageJson = FormatJson(json);
				}
			}
			catch (Exception ex)
			{
				Message nouveauMessage = new Message();
				nouveauMessage.IsQuestion = false;
				nouveauMessage.TexteMessage = ex.Message;
				TousLesMessages.Add(nouveauMessage);
			}
		}


		private void ConvertToMessage(string lastMessageJson)
		{
			if(!string.IsNullOrEmpty(lastMessageJson))
			{
				AnswerQnA answer = JsonConvert.DeserializeObject<AnswerQnA>(lastMessageJson);

				Message nouveauMessage = new Message();
				nouveauMessage.IsQuestion = false;
				nouveauMessage.TexteMessage = answer.answers[0].answer;
				nouveauMessage.TexteMessage = Markdown.Transform(answer.answers[0].answer);

				TousLesMessages.Add(nouveauMessage);
			}

		}



		private const string INDENT_STRING = "    ";
		public static string FormatJson(string str)
		{
			var indent = 0;
			var quoted = false;
			var sb = new StringBuilder();
			for (var i = 0; i < str.Length; i++)
			{
				var ch = str[i];
				switch (ch)
				{
					case '{':
					case '[':
						sb.Append(ch);
						if (!quoted)
						{
							sb.AppendLine();
							Enumerable.Range(0, ++indent).ForEach(item => sb.Append(INDENT_STRING));
						}
						break;
					case '}':
					case ']':
						if (!quoted)
						{
							sb.AppendLine();
							Enumerable.Range(0, --indent).ForEach(item => sb.Append(INDENT_STRING));
						}
						sb.Append(ch);
						break;
					case '"':
						sb.Append(ch);
						bool escaped = false;
						var index = i;
						while (index > 0 && str[--index] == '\\')
							escaped = !escaped;
						if (!escaped)
							quoted = !quoted;
						break;
					case ',':
						sb.Append(ch);
						if (!quoted)
						{
							sb.AppendLine();
							Enumerable.Range(0, indent).ForEach(item => sb.Append(INDENT_STRING));
						}
						break;
					case ':':
						sb.Append(ch);
						if (!quoted)
							sb.Append(" ");
						break;
					default:
						sb.Append(ch);
						break;
				}
			}
			return sb.ToString();
		}
	}

	static class Extensions
	{
		public static void ForEach<T>(this IEnumerable<T> ie, Action<T> action)
		{
			foreach (var i in ie)
			{
				action(i);
			}
		}
	}
}
