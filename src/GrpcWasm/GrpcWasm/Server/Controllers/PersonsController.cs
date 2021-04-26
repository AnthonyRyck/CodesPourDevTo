using GrpcWasm.Server.Datas;
using GrpcWasm.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcWasm.Server.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class PersonsController : ControllerBase
	{
		PersonsManager PersonsManager;

		public PersonsController(PersonsManager manager)
		{
			PersonsManager = manager;
		}

		[HttpGet]
		public List<Person> GetAll()
		{
			return PersonsManager.AllPeople;
		}


	}
}
