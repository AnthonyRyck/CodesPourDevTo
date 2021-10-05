using EveCosmoGremlin.Models;
using Gremlin.Net.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gremlin.Net.Process;
using Gremlin.Net.Process.Traversal;
using Gremlin.Net.Driver.Remote;
using Gremlin.Net.Structure;
using Gremlin.Net.Process.Traversal.Step.Util;
using ExRam.Gremlinq.Providers.WebSocket;
using Microsoft.Extensions.Logging;
using ExRam.Gremlinq.Core;
using EveGremlin.Models;

namespace EveCosmoGremlin
{
	using static Gremlin.Net.Process.Traversal.AnonymousTraversalSource;

	using static ExRam.Gremlinq.Core.GremlinQuerySource;

	public class LoaderToDocker
	{
		private readonly IGremlinQuerySource _g;

		public LoaderToDocker(IGremlinQuerySource g)
		{
			_g = g;
		}

		internal async Task DropBase()
		{
			await _g
				.V()
				.Drop();
		}

		internal async Task CreateAllSystems(List<SolarSystem> solarSystems)
		{
			try
			{
				foreach (var system in solarSystems)
				{
					await _g.AddV(new SolarSystemVertex
					{
						SolarSystemID = system.solarSystemID,
						SolarSystemName = system.solarSystemName,
						Securite = system.securite,
						SecuriteClass = system.securiteClass,
						RegionName = system.regionName
					}).FirstAsync();

					Console.WriteLine("Ajout du système : " + system.solarSystemName);
				}				
			}
			catch (Exception ex)
			{
				Console.WriteLine("ERREUR sur le création des VERTICES : " + ex.Message);
			}
		}

		/// <summary>
		/// Création des relations entre les systèmes
		/// </summary>
		/// <param name="allJumps"></param>
		/// <returns></returns>
		internal async Task CreateEdges(List<Jumps> allJumps)
		{
			try
			{
				foreach (var jump in allJumps)
				{
					var systemDepart = await _g.V<SolarSystemVertex>().Where(x => x.SolarSystemID == jump.FromSystemID);
					var systemArrive = await _g.V<SolarSystemVertex>().Where(x => x.SolarSystemID == jump.ToSystemID);

					if(systemDepart.Length == 0 || systemArrive.Length == 0)
					{
						continue;
					}

					await _g.V(systemDepart.First().Id!)
							.AddE<JumpEdge>()
							.To(__ => __.V(systemArrive.First().Id!))
							.FirstAsync();

					Console.WriteLine("Ajout de la relation : " + systemDepart.First().SolarSystemName + " vers " + systemArrive.First().SolarSystemName);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("ERREUR sur le création des EDGES : " + ex.Message);
			}
		}


		internal async Task GetRegion(string name)
		{

			var test = await _g.V<SolarSystemVertex>().Where(x => x.RegionName == name).ToArrayAsync();

			Console.WriteLine("Il y a " + test.Length + " systèmes dans la région : " + name);
			await Task.Delay(2000);
			foreach (var item in test)
			{
				Console.WriteLine("Nom système : " + item.SolarSystemName);
			}
		}
	}
}
