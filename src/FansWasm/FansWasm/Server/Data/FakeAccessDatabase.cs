﻿using FansWasm.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FansWasm.Server.Data
{
	public class FakeAccessDatabase : IAccessDatabase
	{
		/// <summary>
		/// Collection des fans.
		/// </summary>
		private List<Fan> FansCollection { get; set; }


		public FakeAccessDatabase()
		{
			InitCollection();
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
			Fan newFan = new Fan()
			{
				Id = GetNextId(),
				Nom = nom,
				NombreDeClickRecu = 0,
				DateInscription = DateTime.Now,
				InfoDiverses = "Aucune saisie"
			};
			FansCollection.Add(newFan);

			return newFan;
		}

		/// <summary>
		/// Ajoute un Fan
		/// </summary>
		/// <param name="newFan"></param>
		public Fan AddFan(Fan newFan)
		{
			newFan.Id = GetNextId();

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


		public void InitCollection()
		{
			FansCollection = new List<Fan>();
			FansCollection.Add(new Fan() { Id = 1, Nom = "Michel", NombreDeClickRecu = 0, InfoDiverses = "Plein d'infos", DateInscription = new DateTime(2018, 5, 10) });
			FansCollection.Add(new Fan() { Id = 2, Nom = "Jean", NombreDeClickRecu = 0, InfoDiverses = "Plein d'infos", DateInscription = new DateTime(2018, 5, 10) });
			FansCollection.Add(new Fan() { Id = 3, Nom = "George", NombreDeClickRecu = 0, InfoDiverses = "George en Français est la déclinaison anglaise de Georges", DateInscription = new DateTime(2018, 5, 10) });
			FansCollection.Add(new Fan() { Id = 4, Nom = "Marcel", NombreDeClickRecu = 0, InfoDiverses = "Plein d'infos", DateInscription = new DateTime(2018, 5, 10) });
			FansCollection.Add(new Fan() { Id = 5, Nom = "Christophe", NombreDeClickRecu = 0, InfoDiverses = "Christophe est un prénom masculin qui vient du grec Χριστοφόρος (Christophóros), littéralement « celui qui porte le Christ ». Il est composé à partir des éléments χρίστος (chrístos) « Christ, sacré » et φέρω (phérō) « porter ».", DateInscription = new DateTime(2018, 5, 10) });
			FansCollection.Add(new Fan() { Id = 6, Nom = "Germain", NombreDeClickRecu = 0, InfoDiverses = "Mange des chats, comme ALF.", DateInscription = new DateTime(2008, 12, 10) });
			FansCollection.Add(new Fan() { Id = 7, Nom = "Ronan", NombreDeClickRecu = 0, InfoDiverses = "Aime le chocolat.", DateInscription = new DateTime(2020, 5, 10) });
		}

		/// <summary>
		/// Retourne le prochain ID pour le fan.
		/// </summary>
		/// <returns></returns>
		private int GetNextId()
		{
			int maxId = FansCollection.Max(x => x.Id);
			return maxId + 1;
		}
	}
}
