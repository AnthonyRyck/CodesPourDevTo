using FansApp.Data;
using Microsoft.AspNetCore.Components;

namespace FansApp.ViewModel
{
	public class FanViewModel : IFanViewModel
	{
		private FakeAccessDatabase AccessDatabase { get; set; }

		/// <see cref="IFanViewModel.IdFan"/>
		public int IdFan { get; set; }

		/// <see cref="IFanViewModel.FanSelected"/>
		public Fan FanSelected { get; set; }

		public FanViewModel(FakeAccessDatabase fakeAccessDatabase)
		{
			AccessDatabase = fakeAccessDatabase;
		}

		/// <see cref="IFanViewModel.LoadFan(int)"/>
		public void LoadFan(int id)
		{
			var fan = AccessDatabase.GetFan(id);
			if(fan != null)
			{
				FanSelected = fan;
			}
		}

	}
}
