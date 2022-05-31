using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PersonneController : Controller
	{
		private readonly IDataAccess dataAccess;

		public PersonneController(IDataAccess dataAccess)
		{
			this.dataAccess = dataAccess;
		}

		[HttpGet("personne/{id}")]
		public Personne Get(Guid id)
		{
			var personne = dataAccess.GetPersonne(id);
			return personne;
		}

		[HttpGet("iactionresult/{id}")]
		public IActionResult GetPersonne(Guid id)
		{
			var personne = dataAccess.GetPersonne(id);
			
			if (personne == null)
			{
				return NotFound();
			}

			return Ok(personne);
		}

		[HttpGet("actionresult/{id}")]
		public ActionResult<Personne> GetPersonneById(Guid id)
		{
			var personne = dataAccess.GetPersonne(id);

			if(personne == null)
			{
				return NotFound();
			}

			return personne;
		}

	}
}
