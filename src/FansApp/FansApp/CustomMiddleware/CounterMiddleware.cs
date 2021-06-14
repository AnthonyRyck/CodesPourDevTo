using FansApp.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FansApp.CustomMiddleware
{
	public class CounterMiddleware
	{
		private readonly RequestDelegate _next;

		public CounterMiddleware(RequestDelegate next)
		{
			_next = next;
		}



		public async Task Invoke(HttpContext httpContext, ICounterUser counterUser)
		{
			string ipAppelant = httpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();

			// Appel au prochaine delegate/middleware du pipeline
			// Si pas fait, tout s'arrête !
			await _next(httpContext);

			// Voir la réponse "RETOUR" de SecondMiddleware
			var premierPassageDate = GetInfoDate(httpContext);

			if (!string.IsNullOrEmpty(ipAppelant))
			{
				counterUser.AddIp(ipAppelant, premierPassageDate);
			}
		}


		private string GetInfoDate(HttpContext httpContext)
		{
			string datePremierPassage = string.Empty;

			var haveInfo = httpContext.Items.Any(x => x.Key.ToString() == "InfoFanMiddleware");
			if (haveInfo)
			{
				datePremierPassage = httpContext.Items.FirstOrDefault(x => x.Key.ToString() == "InfoFanMiddleware").Value.ToString();
			}

			return datePremierPassage;
		}

	}
}
