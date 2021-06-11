using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FansApp.Services
{
	public class CounterUser : ICounterUser
	{
		/// <summary>
		/// Liste des IPs
		/// </summary>
		public IEnumerable<string> LesIps { get { return AllInfo; } }


		private List<string> IpList;

		private List<string> AllInfo;

		/// <summary>
		/// Compteur d'IP unique.
		/// </summary>
		public int CounterIpUnique 
		{ 
			get
			{
				return IpList.Count;
			}
		}

		public CounterUser()
		{
			IpList = new List<string>();
			AllInfo = new List<string>();

			// 10 jours en millisecondes
			var tempsEnMillisecond = Convert.ToInt32(TimeSpan.FromHours(24).TotalMilliseconds);
			_timerReset = new Timer(ResetCounter, null, 0, tempsEnMillisecond);
		}

		/// <summary>
		/// IP de l'appelant
		/// </summary>
		/// <param name="ipAppelant"></param>
		/// <param name="date"></param>
		public void AddIp(string ipAppelant, string date)
		{
			if (!IpList.Contains(ipAppelant))
			{
				IpList.Add(ipAppelant);
				AllInfo.Add(ipAppelant + " - " + date);
			}
		}


		private Timer _timerReset;

		#region Private methods


		private void ResetCounter(object state)
		{
			IpList.Clear();
		}

		#endregion
	}
}
