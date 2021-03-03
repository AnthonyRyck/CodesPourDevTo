using FansMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FansMobile.Data
{
	public class FansManager
	{
		private IFanService Service;

		public FansManager(IFanService fanService)
		{
			Service = fanService;
		}


		public async Task<List<Fan>> GetAllFansAsync()
		{
			try
			{
				return await Service.GetFans();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		internal async Task<int> AddClick(int id)
		{
			try
			{
				return await Service.AddClickToFan(id);
			}
			catch (Exception)
			{
			}

			return 0;
		}
	}
}
