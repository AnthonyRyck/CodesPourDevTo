﻿using EveCosmoGremlin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EveCosmoGremlin
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("##### Lancement de l'application ######");
			Console.WriteLine("# Appuyer sur une touche pour commencer l'injection.");
			Console.ReadKey();

			string pathSolarSystem = @"PATH_OF_FILE\systemSolar.json";
			string pathJumps = @"PATH_OF_FILE\Jumps.json";

			Console.WriteLine("Chargement du fichier des systèmes solaires...");
			string jsonContentSystems = File.ReadAllText(pathSolarSystem);
			List<SolarSystem> allSolarSystems = JsonSerializer.Deserialize<List<SolarSystem>>(jsonContentSystems);
			Console.WriteLine($"# Il y a {allSolarSystems.Count} systèmes solaires.");

			Console.WriteLine("Chargement du fichier des jumps...");
			string jsonContentJumps = File.ReadAllText(pathJumps);
			List<Jumps> allJumps = JsonSerializer.Deserialize<List<Jumps>>(jsonContentJumps);
			Console.WriteLine($"# Il y a {allJumps.Count} sauts interstellaires possibles.");

			Console.WriteLine("Fin du chargement des fichiers...");
			Console.WriteLine("# Début de la création du Graph !");
			
			
			Loader loadData = new Loader();

			Console.WriteLine("#--> Création des systèmes (Vertex)");
			loadData.CreateAllSystems(allSolarSystems).Wait();

			Console.WriteLine("#--> Création des liens (Edge)");
			loadData.CreateEdges(allJumps).Wait();

			Console.WriteLine("##### FIN de l'application ######");
			Console.ReadKey();
		}
	}
}