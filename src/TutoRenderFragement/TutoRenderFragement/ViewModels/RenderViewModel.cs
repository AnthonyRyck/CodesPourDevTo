using Microsoft.AspNetCore.Components;
using TutoRenderFragement.Pages;
using TutoRenderFragement.Composants;
using TutoRenderFragement.Entities;
using HtmlAgilityPack;
using System.Linq;

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


		public void DisplayPageWithViewModel()
		{
			RenderFragment Display() => builder =>
			{
				builder.OpenComponent(0, typeof(PageAvecViewModel));
				builder.CloseComponent();
			};

			DisplayRenderFragment = Display();
		}


		public void DisplayHtml()
		{
			string urlFan = "https://fandemo.ctrl-alt-suppr.dev/FanclubPage";

			var web = new HtmlWeb();
			var doc = web.Load(urlFan);

			var nodes = doc.DocumentNode.Descendants("div")
						.ToList()
						.Where(x => x.Attributes.Any() && x.Attributes["class"].Value == "main")
						.FirstOrDefault();

			RenderFragment Display(string html) => builder =>
			{

				builder.AddContent(0, new MarkupString(html));
			};

			DisplayRenderFragment = Display(nodes.InnerHtml);
		}

	}
}
