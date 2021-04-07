using Microsoft.AspNetCore.Components;
using TutoRenderFragement.Pages;
using TutoRenderFragement.Composants;
using TutoRenderFragement.Entities;
using Microsoft.AspNetCore.Components.Rendering;

namespace TutoRenderFragement.ViewModels
{
	public class RenderViewModel : IRenderViewModel
	{
		/// <see cref="IRenderViewModel.DisplayRenderFragment"/>
		public RenderFragment DisplayRenderFragment { get; set; }
				

		/// <see cref="IRenderViewModel.DisplayCounter"/>
		public void DisplayCounter()
		{
			DisplayRenderFragment = CreateDynamicComponent<Counter>();

		}

		private static RenderFragment CreateDynamicComponent<T>() => builder =>
		{
			builder.OpenComponent(0, typeof(T));
			builder.CloseComponent();
		};


		/// <see cref="IRenderViewModel.DisplayCompoAvecParam"/>
		public void DisplayCompoAvecParam()
		{
			Utilisateur utilisateur = new Utilisateur()
			{
				Nom = "Plouf",
				Prenom = "Marcel",
				Age = 123
			};

			RenderFragment CreateCompo() => builder =>
			{
				builder.OpenComponent(0, typeof(CompoAvecParametres));

				builder.AddAttribute(1, "UnNumero", 13);
				builder.AddAttribute(2, "User", utilisateur);

				builder.CloseComponent();
			};

			DisplayRenderFragment = CreateCompo();
		}

		/// <see cref="IRenderViewModel.DisplayFetchData"/>
		public void DisplayFetchData()
		{
			RenderFragment FetchDataDisplay() => builder =>
			{
				builder.OpenComponent(0, typeof(FetchData));
				builder.CloseComponent();
			};

			DisplayRenderFragment = FetchDataDisplay();
		}

	}
}
