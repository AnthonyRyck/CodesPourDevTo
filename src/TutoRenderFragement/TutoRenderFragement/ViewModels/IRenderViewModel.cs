using Microsoft.AspNetCore.Components;

namespace TutoRenderFragement.ViewModels
{
	interface IRenderViewModel
	{
		/// <summary>
		/// Pour afficher un composant.
		/// </summary>
		RenderFragment DisplayRenderFragment { get; set; }

		/// <summary>
		/// Affiche le composant Counter
		/// </summary>
		void DisplayCounter();

		/// <summary>
		/// Affiche un composant avec des paramètres
		/// </summary>
		void DisplayCompoAvecParam();

		/// <summary>
		/// Affiche le composant FetchData (avec un @inject)
		/// </summary>
		void DisplayFetchData();
	}
}
