using FansApp.Data;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FansApp.Services
{
	public class ResetHostedService : IHostedService, IDisposable
	{
		private Timer _timerReset;

		private readonly FakeAccessDatabase FakeAccess;

		#region Constructeur

		public ResetHostedService(FakeAccessDatabase fakeAccess)
		{
			FakeAccess = fakeAccess;
		}

		#endregion

		#region Implement Interfaces

		/// <summary>
		/// Lancement du service
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public Task StartAsync(CancellationToken cancellationToken)
		{
			// 10 jours en millisecondes
			var tempsEnMillisecond = Convert.ToInt32(TimeSpan.FromHours(240).TotalMilliseconds);
			_timerReset = new Timer(ResetCounter, null, 0, tempsEnMillisecond);
			
			return Task.CompletedTask;
		}

		/// <summary>
		/// Arrêt du service
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public Task StopAsync(CancellationToken cancellationToken)
		{
			_timerReset?.Change(Timeout.Infinite, 0);
			return Task.CompletedTask;
		}

		public void Dispose()
		{
			_timerReset?.Dispose();
		}

		#endregion

		#region Private methods


		private void ResetCounter(object state)
		{
			FakeAccess.InitCollection();
		}

		#endregion
	}
}
