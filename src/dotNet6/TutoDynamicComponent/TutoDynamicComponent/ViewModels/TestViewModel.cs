namespace TutoDynamicComponent.ViewModels
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
			Utilisateurs.Add(new Utilisateur() { Age = 21, Nom = "AAA", Prenom = "aaaa" });
			Utilisateurs.Add(new Utilisateur() { Age = 22, Nom = "BBB", Prenom = "bbbb" });
			Utilisateurs.Add(new Utilisateur() { Age = 23, Nom = "CCC", Prenom = "cccc" });
			Utilisateurs.Add(new Utilisateur() { Age = 24, Nom = "DDD", Prenom = "dddd" });
		}
	}
}
