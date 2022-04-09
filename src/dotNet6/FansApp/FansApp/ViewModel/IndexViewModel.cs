using Microsoft.AspNetCore.Components;
using Toolbelt.Blazor.HotKeys;

namespace FansApp.ViewModel
{
	public class IndexViewModel : IIndexViewModel, IDisposable
	{
		private NavigationManager navigationManager;
		private HotKeys HotKeysContext;


		public IndexViewModel(HotKeys hotKeys, NavigationManager navigation)
		{
			navigationManager = navigation;
			HotKeysContext = hotKeys;

			HotKeysContext.CreateContext()
				.Add(ModKeys.Shift, Keys.Num1, OpenFanclubPage, "Ouvrir Fanclub Page.")
				.Add(ModKeys.Shift, Keys.Num2, OpenTitanicPage, "Ouvrir Titanic ML Page.")
				.Add(ModKeys.Shift, Keys.Num3, OpenPage, "Ouvrir la page sur Scss Isolation.")				
				.Add(ModKeys.Shift, Keys.Num4, OpenPage, "Ouvrir la page Middlewares.")
				.Add(ModKeys.Shift, Keys.Num5, OpenPage, "Ouvrir la page FAQ.")
				.Add(ModKeys.Shift, Keys.Num6, OpenPage, "Ouvrir la page de ChatBot.");
		}

		private Task OpenFanclubPage(HotKeyEntry arg)
		{
			navigationManager.NavigateTo("/FanclubPage", true);
			return Task.CompletedTask;
		}

		private Task OpenTitanicPage(HotKeyEntry arg)
		{
			navigationManager.NavigateTo("/titanic", true);
			return Task.CompletedTask;
		}

		private Task OpenPage(HotKeyEntry arg)
		{
			switch (arg.Key)
			{
				case Keys.Num3:
					navigationManager.NavigateTo("/drawcss", true);				
					break;
				case Keys.Num4:
					navigationManager.NavigateTo("/intergiciel-Errrk-disgusting", true);
					break;
				case Keys.Num5:
					navigationManager.NavigateTo("/faq", true);
					break;
				case Keys.Num6:
					navigationManager.NavigateTo("/webchat", true);
					break;
				default:
					navigationManager.NavigateTo("/", true);
					break;
			}
			return Task.CompletedTask;
		}

		public async void Dispose()
		{
			await HotKeysContext.DisposeAsync();
		}
	}
}
