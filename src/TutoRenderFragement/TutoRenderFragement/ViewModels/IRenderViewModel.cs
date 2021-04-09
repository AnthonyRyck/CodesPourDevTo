using Microsoft.AspNetCore.Components;
using System;

namespace TutoRenderFragement.ViewModels
{
	interface IRenderViewModel
	{
		/// <summary>
		/// Pour afficher un composant.
		/// </summary>
		RenderFragment DisplayRenderFragment { get; set; }

		/// <summary>
		/// Pour avoir accès à StateHasChanged depuis le ViewModel
		/// </summary>
		/// <param name="stateHasChanged"></param>
		void SetStateHasChanged(Action stateHasChanged);

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
