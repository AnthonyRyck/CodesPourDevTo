using System.Collections.Generic;

namespace FansApp.Data
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