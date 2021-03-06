using FansMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FansMobile.Services
{
	public interface IFanService
	{
		/// <summary>
		/// Récupère la liste des fans
		/// </summary>
		/// <returns></returns>
		Task<List<Fan>> GetFans();

		/// <summary>
		/// Ajoute un nouveau fan
		/// </summary>
		/// <param name="newFan"></param>
		/// <returns></returns>
		Task AddNewFan(Fan newFan);

		/// <summary>
		/// Ajoute un click à un fan.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<int> AddClickToFan(int id);
	}
}
