using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FansApp.Models
{
	public class Message
	{
		/// <summary>
		/// Indique si c'est une question.
		/// </summary>
		public bool IsQuestion { get; set; }

		/// <summary>
		/// Contient le texte du message.
		/// </summary>
		public string TexteMessage { get; set; }
	}






    // AnswerQnA myDeserializedClass = JsonConvert.DeserializeObject<AnswerQnA>(myJsonResponse); 
    public class AnswerQnA
    {
        public List<Answer> answers { get; set; }
        public bool activeLearningEnabled { get; set; }
    }

    public class Context
    {
        public bool isContextOnly { get; set; }
        public List<object> prompts { get; set; }
    }

    public class Answer
    {
        public List<string> questions { get; set; }
        public string answer { get; set; }
        public double score { get; set; }
        public int id { get; set; }
        public string source { get; set; }
        public bool isDocumentText { get; set; }
        public List<object> metadata { get; set; }
        public Context context { get; set; }
    }


}
