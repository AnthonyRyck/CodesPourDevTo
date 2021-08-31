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

namespace FansApp.ViewModel
{
	public class WebChatViewModel : IWebChatViewModel
	{
		/// <see cref="IWebChatViewModel.TousLesMessages"/>
		public List<Message> TousLesMessages { get; set; }

		/// <see cref="IWebChatViewModel.LastMessageJson"/>
		public string LastMessageJson { get; private set; }

		public string Question { get; set; }

		private Markdown _markdown;


		public WebChatViewModel()
		{
			var options = new MarkdownOptions
			{
				AutoHyperlink = true,
				LinkEmails = true,
				QuoteSingleLine = true,
				StrictBoldItalic = true
			};

			_markdown = new Markdown(options);
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
			string urlQnA = "https://qna-ctrlaltsuppr.azurewebsites.net/qnamaker/knowledgebases/****ID-APP*****/generateAnswer";

			HttpWebRequest httpWebRequest = WebRequest.CreateHttp(urlQnA);
			httpWebRequest.ContentType = "application/json";
			httpWebRequest.Method = "POST";
			httpWebRequest.Headers.Add("Authorization", " EndpointKey ***YOUR-ENDPOINT-KEY*** "); 

			using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
			{
				string json = "{ \"question\" :\"" + question + "\"}";

				streamWriter.Write(json);
				streamWriter.Flush();
			}
			var httpResponse = (HttpWebResponse) (await httpWebRequest.GetResponseAsync());

			using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
			{
				LastMessageJson = await streamReader.ReadToEndAsync();

				// Convertion en Message
				ConvertToMessage(LastMessageJson);
			}
		}


		private void ConvertToMessage(string lastMessageJson)
		{
			if(!string.IsNullOrEmpty(lastMessageJson))
			{
				AnswerQnA answer = JsonConvert.DeserializeObject<AnswerQnA>(lastMessageJson);

				Message nouveauMessage = new Message();
				nouveauMessage.IsQuestion = false;
				nouveauMessage.TexteMessage = _markdown.Transform(answer.answers[0].answer);
			}

		}
	}
}
