using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FansApp.Data
{
	/// <summary>
	/// 
	/// </summary>
	public class FakeAccessDatabase
	{
		/// <summary>
		/// Collection des fans.
		/// </summary>
		private List<Fan> FansCollection { get; set; }


		public FakeAccessDatabase()
		{
			FansCollection = new List<Fan>();
			FansCollection.Add(new Fan() { Id=1 , Nom = "Michel", NombreDeClickRecu = 0, InfoDiverse = "Plein d'infos" });
			FansCollection.Add(new Fan() { Id=2 , Nom = "Jean", NombreDeClickRecu = 0, InfoDiverse = "Plein d'infos" });
			FansCollection.Add(new Fan() { Id=3 , Nom = "George", NombreDeClickRecu = 0, InfoDiverse = "George en Français est la déclinaison anglaise de Georges" });
			FansCollection.Add(new Fan() { Id=4 , Nom = "Marcel", NombreDeClickRecu = 0, InfoDiverse = "Plein d'infos" });
			FansCollection.Add(new Fan() { Id=5 , Nom = "Christophe", NombreDeClickRecu = 0, InfoDiverse = "Christophe est un prénom masculin qui vient du grec Χριστοφόρος (Christophóros), littéralement « celui qui porte le Christ ». Il est composé à partir des éléments χρίστος (chrístos) « Christ, sacré » et φέρω (phérō) « porter »." });
			FansCollection.Add(new Fan() { Id=6 , Nom = "Germain", NombreDeClickRecu = 0, InfoDiverse = "Mange des chats, comme ALF." });
			FansCollection.Add(new Fan() { Id=7 , Nom = "Ronan", NombreDeClickRecu = 0, InfoDiverse = "Aime le chocolat." });
		}

		/// <summary>
		/// Retourne la liste des Fans
		/// </summary>
		/// <returns></returns>
		public List<Fan> GetAllFans()
		{
			return FansCollection.ToList();
		}

		/// <summary>
		/// Retourne le fan par rapport à l'ID
		/// </summary>
		/// <returns></returns>
		public Fan GetFan(int id)
		{
			return FansCollection.Find(x => x.Id == id);
		}

		/// <summary>
		/// Ajoute un click au fan.
		/// </summary>
		/// <param name="id"></param>
		public void AddClick(int id)
		{
			// Ajout un click au compteur.
			FansCollection.Find(x => x.Id == id).NombreDeClickRecu += 1;
		}

		/// <summary>
		/// Enlève un click au fan.
		/// </summary>
		/// <param name="id"></param>
		public void RemoveClick(int id)
		{
			// Enlève un click au compteur.
			FansCollection.Find(x => x.Id == id).NombreDeClickRecu -= 1;
		}

		/// <summary>
		/// Ajoute un nouveau Fan.
		/// </summary>
		/// <param name="nom"></param>
		public Fan AddFan(string nom)
		{
			int maxId = FansCollection.Max(x => x.Id);

			Fan newFan = new Fan() { Id = (maxId + 1), Nom = nom, NombreDeClickRecu = 0 };
			FansCollection.Add(newFan);

			return newFan;
		}

		/// <summary>
		/// Supprime un fan.
		/// </summary>
		/// <param name="id"></param>
		public void RemoveFan(int id)
		{
			FansCollection.RemoveAll(x => x.Id == id);
		}

	}
}
