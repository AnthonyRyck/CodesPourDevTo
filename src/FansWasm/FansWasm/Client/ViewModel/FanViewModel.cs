using FansWasm.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FansWasm.Client.ViewModel
{
	public class FanViewModel : IFanViewModel
	{
		//private IAccessDatabase AccessDatabase { get; set; }

		/// <see cref="IFanViewModel.IdFan"/>
		public int IdFan { get; set; }

		/// <see cref="IFanViewModel.FanSelected"/>
		public Fan FanSelected { get; set; }

		//public FanViewModel(IAccessDatabase fakeAccessDatabase)
		//{
		//	AccessDatabase = fakeAccessDatabase;
		//}

		/// <see cref="IFanViewModel.LoadFan(int)"/>
		public void LoadFan(int id)
		{
			//var fan = AccessDatabase.GetFan(id);
			//if(fan != null)
			//{
			//	FanSelected = fan;
			//}
		}
	}
}
