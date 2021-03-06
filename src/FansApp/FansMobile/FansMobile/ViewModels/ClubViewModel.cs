using FansMobile.Services;
using FansMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FansMobile.ViewModels
{
	public class ClubViewModel : BaseViewModel
	{
		/// <summary>
		/// Notre liste de Fan
		/// </summary>
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

		/// <summary>
		/// Notre FanService pour communiquer avec
		/// le BackEnd.
		/// </summary>
		private IFanService FanService => DependencyService.Get<IFanService>();


		public ClubViewModel()
		{
			Title = "Club";
		}

		/// <summary>
		/// Charge tous les fans.
		/// </summary>
		/// <returns></returns>
		public async Task LoadFans()
		{
			AllFans = await FanService.GetFans();
		}
	}
}
