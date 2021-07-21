using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace FansApp.CustomMiddleware
{
	public class SecondMiddleware
	{
		private readonly RequestDelegate _next;


		public SecondMiddleware(RequestDelegate next)
		{
			_next = next;
		}


		public async Task Invoke(HttpContext httpContext)
		{
			httpContext.Items.Add("InfoFanMiddleware", DateTime.Now.ToString("g"));	
			await _next(httpContext);
		}
	}
}
