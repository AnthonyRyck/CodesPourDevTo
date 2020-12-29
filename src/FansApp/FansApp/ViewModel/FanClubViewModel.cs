using FansApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FansApp.ViewModel
{
	public class FanClubViewModel : IFanClubViewModel
	{
		private FakeAccessDatabase fakeAccess;

		public FanClubViewModel(FakeAccessDatabase accessDataBase)
		{
			fakeAccess = accessDataBase;
			AllFansCollection = fakeAccess.GetAllFans();

			CanDisplayNewFan = false;
		}

		#region Implement IFanClubViewModel

		///<inheritdoc cref="IFanClubViewModel.CanDisplayNewFan"/>
		public bool CanDisplayNewFan { get; set; }

		///<inheritdoc cref="IFanClubViewModel.AllFansCollection"/>
		public List<Fan> AllFansCollection { get; set; }

		///<inheritdoc cref="IFanClubViewModel.GetFans"/>
		public void GetFans()
		{
			AllFansCollection = fakeAccess.GetAllFans();
		}

		///<inheritdoc cref="IFanClubViewModel.DisplayNewFan"/>
		public void DisplayNewFan()
		{
			CanDisplayNewFan = true;
		}

		///<inheritdoc cref="IFanClubViewModel.CancelNewFan"/>
		public void CancelNewFan()
		{
			CanDisplayNewFan = false;
		}

		///<inheritdoc cref="IFanClubViewModel.AddClick(int)"/>
		public void AddClick(int id)
		{
			fakeAccess.AddClick(id);
		}

		///<inheritdoc cref="IFanClubViewModel.RemoveClick(int)"/>
		public void RemoveClick(int id)
		{
			fakeAccess.RemoveClick(id);
		}

		///<inheritdoc cref="IFanClubViewModel.AddFan(string)"/>
		public void AddFan(string nom)
		{
			// Ajout en "base de donnée"
			Fan nouveauFan = fakeAccess.AddFan(nom);
			
			// Ajout dans la collection du ViewModel
			AllFansCollection.Add(nouveauFan);

			// Fermeture de la fenêtre.
			CanDisplayNewFan = false;
		}

		///<inheritdoc cref="IFanClubViewModel.RemoveFan(int)"/>
		public void RemoveFan(int id)
		{
			fakeAccess.RemoveFan(id);
			AllFansCollection.RemoveAll(x => x.Id == id);
		}

		#endregion

	}
}
