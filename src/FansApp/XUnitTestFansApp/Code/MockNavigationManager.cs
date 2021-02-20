using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTestFansApp.Code
{
	public class MockNavigationManager : NavigationManager
	{
		private const string BASE_URI = "http://test.localhost.com:1664/";

		public MockNavigationManager()
		{
			base.Initialize(BASE_URI, BASE_URI + "test");
		}

		/// <summary>
		/// Méthode à implémenter de NavigationManager
		/// </summary>
		/// <param name="uri"></param>
		/// <param name="forceLoad"></param>
		protected override void NavigateToCore(string uri, bool forceLoad)
		{
			// indicateur si appel à une méthode "NavigateTo" de NavigationManager.
			WasNavigateInvoked = true;

			// Récupération de l'URI demandé.
			GoToUri = uri;
		}

		public bool WasNavigateInvoked { get; private set; }

		public string GoToUri { get; private set; }

	}
}
