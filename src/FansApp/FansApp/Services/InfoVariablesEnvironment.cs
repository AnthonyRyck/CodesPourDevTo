using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FansApp.Services
{
	public class InfoVariablesEnvironment
	{
		public string QnaMakerEndPoint { get; private set; }
		public string QnaMakerKey { get; private set; }
		public string QnaIdApp { get; private set; }

		public InfoVariablesEnvironment(string qnaEndpoint, string qnaKey, string qnaIdApp)
		{
			QnaMakerEndPoint = qnaEndpoint;
			QnaMakerKey = qnaKey;
			QnaIdApp = qnaIdApp;
		}
	}
}
