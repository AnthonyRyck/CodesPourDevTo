using EveCosmoGremlin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace EveCosmoGremlin
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("##### Lancement de l'application ######");
			Console.WriteLine("# Appuyer sur une touche pour commencer l'injection.");
			Console.ReadKey();

			string pathSolarSystem = @"C:\CodeSource\Github\AnthonyRyck\CodesPourDevTo\src\Files\EveOnline\systemSolar.json";
			string pathJumps = @"C:\CodeSource\Github\AnthonyRyck\CodesPourDevTo\src\Files\EveOnline\Jumps.json";

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

			//Loader loadData = new Loader();
			//
			//Console.WriteLine("#--> Création des systèmes (un Vertex / des Vertices !)");
			//Console.WriteLine("Petite pause.....");
			//Task.Delay(1000).Wait();
			//loadData.CreateAllSystems(allSolarSystems).Wait();
			//
			//Console.WriteLine("#--> Création des liens (Edge)");
			//Console.WriteLine("Petite pause.....");
			//Task.Delay(1000).Wait();
			//loadData.CreateEdges(allJumps).Wait();


			LoaderToDocker loadData = new LoaderToDocker();

			//Console.WriteLine("#--> Création des systèmes (un Vertex / des Vertices !)");
			//Console.WriteLine("Petite pause.....");
			//Task.Delay(1000).Wait();
			//loadData.CreateAllSystems(allSolarSystems).Wait();

			//Console.WriteLine("#--> Création des liens (Edge)");
			//Console.WriteLine("Petite pause.....");
			//Task.Delay(1000).Wait();
			//loadData.CreateEdges(allJumps).Wait();

			loadData.GetRegion("The Forge").Wait();

			Console.WriteLine("##### FIN de l'application ######");
			Console.ReadKey();
		}
	}
}
