namespace TutoDynamicComponent.ViewModels
{
    public interface IDynamicCompoViewModel
    {
        /// <summary>
        /// Donne le type a afficher
        /// </summary>
        Type TypeCompo { get; }

        /// <summary>
        /// Pour passer les paramètres s'il y a.
        /// </summary>
        Dictionary<string, object> Properties { get; }

        /// <summary>
        /// Permet d'afficer le composant Counter.razor
        /// </summary>
        void DisplayCounter();

        /// <summary>
        /// Affiche un composant qui a un paramètre
        /// </summary>
        void DisplayCompoAvecParam();

        /// <summary>
        /// Affiche un composant avec "/page".
        /// </summary>
        void DisplayFetchDataPage();

        /// <summary>
        /// Affiche un composant avec son ViewModel
        /// </summary>
        void DisplayPageWithViewModel();

        /// <summary>
        /// Affiche un composant avec un EventCallback
        /// </summary>
        void DisplayWithEventCallback();

        /// <summary>
		/// Pour avoir accès à StateHasChanged depuis le ViewModel
		/// </summary>
		/// <param name="stateHasChanged"></param>
		void SetStateHasChanged(Action stateHasChanged);
    }
}
