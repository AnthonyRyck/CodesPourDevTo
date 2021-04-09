using Microsoft.AspNetCore.Components;
using TutoRenderFragement.Pages;
using TutoRenderFragement.Composants;
using TutoRenderFragement.Entities;
using HtmlAgilityPack;
using System.Linq;
using System.Collections.Generic;
using System;

namespace TutoRenderFragement.ViewModels
{
	public class RenderViewModel : IRenderViewModel
	{
		/// <see cref="IRenderViewModel.DisplayRenderFragment"/>
		public RenderFragment DisplayRenderFragment { get; set; }


		private IReceiverViewModel AutreViewModel;

		public RenderViewModel(IReceiverViewModel viewModel)
		{
			AutreViewModel = viewModel;
		}
				

		/// <see cref="IRenderViewModel.DisplayCounter"/>
		public void DisplayCounter()
		{
			RenderFragment CreateCompo() => builder =>
			{
				builder.OpenComponent(0, typeof(Counter));
				builder.CloseComponent();
			};

			DisplayRenderFragment = CreateCompo();
		}

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

				// Soit déclarer pour chaque paramètre.
				//builder.AddAttribute(1, "UnNumero", 13);
				//builder.AddAttribute(2, "User", utilisateur);

				// Possible de faire aussi quand plusieurs paramètres
				List<KeyValuePair<string,object>> attributes = new List<KeyValuePair<string, object>>();
				attributes.Add(new KeyValuePair<string, object>("UnNumero", 13));
				attributes.Add(new KeyValuePair<string, object>("User", utilisateur));

				builder.AddMultipleAttributes(1, attributes);

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

		/// <see cref="IRenderViewModel.DisplayPageWithViewModel"/>
		public void DisplayPageWithViewModel()
		{
			RenderFragment Display() => builder =>
			{
				builder.OpenComponent(0, typeof(PageAvecViewModel));
				builder.CloseComponent();
			};

			DisplayRenderFragment = Display();
		}

		/// <see cref="IRenderViewModel.DisplayHtml"/>
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

		/// <see cref="IRenderViewModel.DisplayWithEventCallback"/>
		public void DisplayWithEventCallback()
		{
			RenderFragment CreateCompo() => builder =>
			{
				builder.OpenComponent(0, typeof(CompoAvecEventCallBack));

				// Ajout pour EventCallBack
				var eventCallbackAddClick = EventCallback.Factory.Create(AutreViewModel, AutreViewModel.Click);
				builder.AddAttribute(1, "ClickOnMe", eventCallbackAddClick);

				builder.CloseComponent();
			};

			DisplayRenderFragment = CreateCompo();
		}

	}
}
