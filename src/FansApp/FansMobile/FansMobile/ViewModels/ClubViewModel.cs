using FansMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FansMobile.ViewModels
{
	public class ClubViewModel : BaseViewModel
	{
		public List<Fan> AllFans
		{
			get { return _propertyName; }
			set
			{
				_propertyName = value;
				OnNotifyPropertyChanged();
			}
		}
		private List<Fan> _propertyName;




		public ClubViewModel()
		{
			Title = "Club";
		}


		public async Task LoadFans()
		{
			AllFans = await App.FansManager.GetAllFansAsync();
		}
	}
}
