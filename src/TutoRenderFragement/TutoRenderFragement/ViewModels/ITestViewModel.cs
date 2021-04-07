using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoRenderFragement.Entities;

namespace TutoRenderFragement.ViewModels
{
	public interface ITestViewModel
	{
		List<Utilisateur> Utilisateurs { get; set; }

		int NombreClic { get; set; }


		void AddClick();
	}
}
