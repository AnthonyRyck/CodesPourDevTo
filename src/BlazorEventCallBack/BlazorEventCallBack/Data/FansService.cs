using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorEventCallBack.Data
{
	public class FansService
	{
		/// <summary>
		/// Collection des fans.
		/// </summary>
		public List<Fan> FansCollection { get; set; }


		public FansService()
		{
			FansCollection = new List<Fan>();
			FansCollection.Add(new Fan() { Nom = "Fan1", NombreDeClickRecu = 0 });
			FansCollection.Add(new Fan() { Nom = "Fan2", NombreDeClickRecu = 0 });
			FansCollection.Add(new Fan() { Nom = "Fan3", NombreDeClickRecu = 0 });
			FansCollection.Add(new Fan() { Nom = "Fan4", NombreDeClickRecu = 0 });
			FansCollection.Add(new Fan() { Nom = "Fan5", NombreDeClickRecu = 0 });
			FansCollection.Add(new Fan() { Nom = "Fan6", NombreDeClickRecu = 0 });
			FansCollection.Add(new Fan() { Nom = "Fan7", NombreDeClickRecu = 0 });
		}



		public void GetClick(string nom)
		{
			// Ajout un click qu compteur.
			FansCollection.Find(x => x.Nom == nom).NombreDeClickRecu += 1;
		}

	}
}
