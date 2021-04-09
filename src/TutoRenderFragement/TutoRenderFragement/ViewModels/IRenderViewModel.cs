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
		/// Affiche un composant avec un paramètre EventCallback
		/// </summary>
		void DisplayWithEventCallback();

		/// <summary>
		/// Affiche le composant FetchData (avec un @inject)
		/// </summary>
		void DisplayFetchData();

		/// <summary>
		/// Affiche un composant avec un ViewModel injecté
		/// </summary>
		void DisplayPageWithViewModel();

		/// <summary>
		/// Affiche du code HTML
		/// </summary>
		void DisplayHtml();
				
	}
}
