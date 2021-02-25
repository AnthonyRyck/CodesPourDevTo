using FansWasm.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FansWasm.Server.Data
{
	public interface IAccessDatabase
	{
		void AddClick(int id);
		Fan AddFan(Fan newFan);
		Fan AddFan(string nom);
		List<Fan> GetAllFans();
		Fan GetFan(int id);
		void RemoveClick(int id);
		void RemoveFan(int id);

		void InitCollection();
	}
}
