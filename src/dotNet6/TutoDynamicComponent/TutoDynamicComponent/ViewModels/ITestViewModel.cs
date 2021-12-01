namespace TutoDynamicComponent.ViewModels
{
	public interface ITestViewModel
	{
		List<Utilisateur> Utilisateurs { get; set; }

		int NombreClic { get; set; }


		void AddClick();
	}
}
