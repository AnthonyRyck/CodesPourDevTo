using HtmlAgilityPack;

using Microsoft.AspNetCore.Components;

namespace TutoDynamicComponent.ViewModels
{
    public class DynamicCompoViewModel : IDynamicCompoViewModel
    {
        IReceiverViewModel AutreViewModel;
        private Action StateHasChanged;

        public DynamicCompoViewModel(IReceiverViewModel receiverViewModel)
	    {
            AutreViewModel = receiverViewModel;
        }




        /// <see cref="IDynamicCompoViewModel.TypeCompo"/>
        public Type TypeCompo { get; private set; }

        /// <see cref="IDynamicCompoViewModel.Properties"/>
        public Dictionary<string, object> Properties { get; private set;  } = new Dictionary<string, object>();

        /// <see cref="IRenderViewModel.SetStateHasChanged(Action)"/>
		public void SetStateHasChanged(Action stateHasChanged)
        {
            StateHasChanged = stateHasChanged;
        }


        /// <see cref="IDynamicCompoViewModel.DisplayCounter"/>
        public void DisplayCounter()
        {
            // Ne pas oublier --> sinon Exception
            Properties.Clear();
            TypeCompo = typeof(Counter);
        }

        /// <see cref="IDynamicCompoViewModel.DisplayCompoAvecParam"/>
        public void DisplayCompoAvecParam()
        {
            // Ne pas oublier --> sinon Exception
            Properties.Clear();
            Properties.Add("UnNumero", 12);

            Utilisateur user = new Utilisateur() { Age = 24, Nom = "Ryck", Prenom = "Anthony" };
            Properties.Add("User", user);

            TypeCompo = typeof(CompoAvecParametre);
        }

        /// <see cref="IDynamicCompoViewModel.DisplayFetchDataPage"/>
        public void DisplayFetchDataPage()
        {
            // Ne pas oublier --> sinon Exception
            Properties.Clear();
            TypeCompo = typeof(FetchData);
        }

        /// <see cref="IDynamicCompoViewModel.DisplayPageWithViewModel"/>
        public void DisplayPageWithViewModel()
        {
            // Ne pas oublier --> sinon Exception
            // MARTEAU thérapie !
            Properties.Clear();
            TypeCompo = typeof(PageAvecViewModel);
        }

        public void DisplayWithEventCallback()
        {
            Properties.Clear();

            var eventCallbackAddClick = EventCallback.Factory.Create(AutreViewModel, CallClick);
            
            Properties.Add("ClickOnMe", eventCallbackAddClick);
            Properties.Add("CounterClick", monCompteur);
            TypeCompo = typeof(CompoAvecEventCallback);
        }

        int monCompteur;

        private void CallClick()
        {
            monCompteur++;
            StateHasChanged.Invoke();
        }
    }
}
