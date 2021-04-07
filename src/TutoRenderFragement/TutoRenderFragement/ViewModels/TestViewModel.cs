using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoRenderFragement.Entities;

namespace TutoRenderFragement.ViewModels
{
	public class TestViewModel : ITestViewModel
	{
		public List<Utilisateur> Utilisateurs { get; set; }

		public int NombreClic { get; set; }


		public TestViewModel()
		{
			Utilisateurs = new List<Utilisateur>();
			InitUtilisateurs();
		}


		public void AddClick()
		{
			NombreClic++;
		}


		private void InitUtilisateurs()
		{
			Utilisateurs.Add(new Utilisateur() { Age = 11, Nom = "AAA", Prenom = "aaaa" });
			Utilisateurs.Add(new Utilisateur() { Age = 11, Nom = "BBB", Prenom = "bbbb" });
			Utilisateurs.Add(new Utilisateur() { Age = 11, Nom = "CCC", Prenom = "cccc" });
			Utilisateurs.Add(new Utilisateur() { Age = 11, Nom = "DDD", Prenom = "dddd" });
		}
	}
}
