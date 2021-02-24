using FansWasm.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FansWasm.Client.ViewModel
{
	public interface IFanViewModel
	{
		/// <summary>
		/// Fan recherché.
		/// </summary>
		Fan FanSelected { get; set; }

		/// <summary>
		/// ID du fan recherché
		/// </summary>
		int IdFan { get; set; }

		/// <summary>
		/// Charge le Fan donné en ID
		/// </summary>
		/// <param name="id"></param>
		void LoadFan(int id);
	}
}
