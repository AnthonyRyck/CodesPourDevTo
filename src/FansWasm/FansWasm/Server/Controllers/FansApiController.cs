﻿using FansWasm.Server.Data;
using FansWasm.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FansWasm.Server.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class FansApiController : ControllerBase
	{
		private IAccessDatabase AccessDatabase;


		public FansApiController(IAccessDatabase accessDatabase)
		{
			AccessDatabase = accessDatabase;
		}

		[HttpGet]
		public IEnumerable<Fan> Get()
		{
			return AccessDatabase.GetAllFans().ToArray();
		}

		[HttpGet("{id}")]
		public Fan Get(int id)
		{
			var fan = AccessDatabase.GetFan(id);

			if (fan == null)
			{
				fan = new Fan()
				{
					Id = id,
					Nom = "Aucun nom",
					InfoDiverses = "Aucun fan de trouvé avec cet ID",
					NombreDeClickRecu = 0,
					DateInscription = DateTime.Now
				};
			}

			return fan;
		}

		[HttpDelete]
		public void RemoveFan(int id)
		{
			AccessDatabase.RemoveFan(id);
		}

		[HttpPost("{id}")]
		public async Task<ActionResult<int>> AddClick(int id)
		{
			AccessDatabase.AddClick(id);
			return AccessDatabase.GetFan(id).NombreDeClickRecu;
		}

		[HttpPost("newfan/{nom}")]
		public async Task<ActionResult<Fan>> AddFan(string nom)
		{
			var nouveauFan = AccessDatabase.AddFan(nom);
			return nouveauFan;
		}

		[HttpPost("newfan")]
		public async Task<ActionResult<int>> AddNewFan(Fan fan)
		{
			var nouveauFan = AccessDatabase.AddFan(fan);
			return nouveauFan.Id;
		}
	}
}
