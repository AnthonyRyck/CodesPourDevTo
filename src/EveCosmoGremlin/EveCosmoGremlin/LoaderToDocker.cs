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

namespace EveCosmoGremlin
{
	using static Gremlin.Net.Process.Traversal.AnonymousTraversalSource;

	using static ExRam.Gremlinq.Core.GremlinQuerySource;

	public class LoaderToDocker
	{
		GremlinServer _server;

		public LoaderToDocker()
		{
			_server = new GremlinServer("localhost", 8182);
		}


		internal async Task CreateAllSystems(List<SolarSystem> solarSystems)
		{
			try
			{
				
				using (var gremlinClient = new GremlinClient(_server))
				{
					foreach (var system in solarSystems)
					{
						Console.WriteLine($"Ajout du système : {system.solarSystemName}");

						string request = system.ToQueryAddVertex();
						await gremlinClient.SubmitAsync<dynamic>(request);
					}
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
				using (var gremlinClient = new GremlinClient(_server))
				{
					var g = Traversal().WithRemote(new DriverRemoteConnection(gremlinClient));
					
					foreach (var jump in allJumps)
					{
						Console.WriteLine($"Ajout de la relation JUMP de : {jump.FromSystem} vers {jump.ToSystem}");

						g.V().Has("solar", jump.FromSystemID)
							.AddE("jumpTo")
							.To(g.V().Has("solar", jump.ToSystemID));
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("ERREUR sur le création des EDGES : " + ex.Message);
			}
		}


		//internal async Task GetRegionOld(string name)
		//{


		//	using (var gremlinClient = new GremlinClient(_server))
		//	{
		//		var g = Traversal().WithRemote(new DriverRemoteConnection(gremlinClient));

		//		var test = g.V().Has("SystemSolar", "region", name).ToList();



		//		var result = g.V().ValueMap<Vertex, SolarSystemVertex>("region", "name", "security", "solar").Has("region", name).ToList();
		//	}
		//}

		internal async Task GetRegion(string name)
		{

			var gg = g.ConfigureEnvironment(env => env //We call ConfigureEnvironment twice so that the logger is set on the environment from now on.
				.ConfigureOptions(options => options
						.SetValue(WebSocketGremlinqOptions.QueryLogLogLevel, LogLevel.None))
						   .UseGremlinServer(builder => builder
						.AtLocalhost()));

			gg.V().As("region", name). //hasLabel('Person').has('Age', gt(30))

			var test = await gg.V<SolarSystemVertex>().Where(x => x.region.Value == name).ToArrayAsync();
		}
	}
}
