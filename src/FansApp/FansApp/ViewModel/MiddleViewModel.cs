using FansApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FansApp.ViewModel
{
	public class MiddleViewModel : IMiddleViewModel
	{
		private ICounterUser Counter;

		public int NombreIpUnique { get { return Counter.CounterIpUnique; } }
		
		public IEnumerable<string> LesIps { get { return Counter.LesIps; } }


		public MiddleViewModel(ICounterUser counterUser)
		{
			Counter = counterUser;
		}
	}
}
