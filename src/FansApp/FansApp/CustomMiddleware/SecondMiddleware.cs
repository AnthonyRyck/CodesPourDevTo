using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
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
			httpContext.Items.Add("InfoFanMiddleware", "Ralalalala !!");	
			await _next(httpContext);
		}
	}
}
