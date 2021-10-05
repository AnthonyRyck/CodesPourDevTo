//using EveCosmoGremlin.Models;
//using Gremlin.Net.Driver;
//using Gremlin.Net.Structure.IO.GraphSON;
//using System;
//using System.Collections.Generic;
//using System.Net.WebSockets;
//using System.Threading.Tasks;

//namespace EveCosmoGremlin
//{
//	public class Loader
//	{
//		// Point de terminaison Gremlin sans le wss://
//		//private static string hostname = "ACCOUNT_NAME.gremlin.cosmos.azure.com";
//		//private static int port = 443;
//		//private static string authKey = "YOUR_PRIMARY_KEY";
//		//private static string database = "DB_NAME";
//		//private static string collection = "GRAPH_NAME";

//		private static string hostname = "ACCOUNT_NAME.gremlin.cosmos.azure.com";
//		private static int port = 443;
//		private static string authKey = "YOUR_PRIMARY_KEY";
//		private static string database = "DB_NAME";
//		private static string collection = "GRAPH_NAME";

//		private GremlinServer ServerGremlin;

//		public Loader()
//		{
//			string containerLink = "/dbs/" + database + "/colls/" + collection;
//			Console.WriteLine($"Connecting to: host: {hostname}, port: {port}, container: {containerLink}, ssl: {true}");
//			ServerGremlin = new GremlinServer(hostname, port, enableSsl: true,
//													username: containerLink,
//													password: authKey);
//		}
		
//		/// <summary>
//		/// Création des "Noeuds"/Vertices pour chaque système solaire.
//		/// </summary>
//		/// <param name="solarSystems"></param>
//		/// <returns></returns>
//		internal async Task CreateAllSystems(List<SolarSystem> solarSystems)
//		{
//			try
//			{
//				ConnectionPoolSettings connectionPoolSettings = new ConnectionPoolSettings()
//				{
//					MaxInProcessPerConnection = 10,
//					PoolSize = 30
//				};

//				var webSocketConfiguration =
//					new Action<ClientWebSocketOptions>(options =>
//					{
//						options.KeepAliveInterval = TimeSpan.FromSeconds(10);
//					});

//				using (var gremlinClient = new GremlinClient(
//											ServerGremlin,
//											new GraphSON2Reader(),
//											new GraphSON2Writer(),
//											GremlinClient.GraphSON2MimeType,
//											connectionPoolSettings,
//											webSocketConfiguration))
//				{
//					foreach (var system in solarSystems)
//					{
//						Console.WriteLine($"Ajout du système : {system.solarSystemName}");

//						string request = system.ToQueryAddVertex();
//						await gremlinClient.SubmitAsync<dynamic>(request);
//					}
//				}
//			}
//			catch (Exception ex)
//			{
//				Console.WriteLine("ERREUR sur le création des VERTICES : " + ex.Message);
//			}
//		}

//		/// <summary>
//		/// Création des relations entre les systèmes
//		/// </summary>
//		/// <param name="allJumps"></param>
//		/// <returns></returns>
//		internal async Task CreateEdges(List<Jumps> allJumps)
//		{
//			try
//			{
//				ConnectionPoolSettings connectionPoolSettings = new ConnectionPoolSettings()
//				{
//					MaxInProcessPerConnection = 10,
//					PoolSize = 30
//				};

//				var webSocketConfiguration =
//					new Action<ClientWebSocketOptions>(options =>
//					{
//						options.KeepAliveInterval = TimeSpan.FromSeconds(10);
//					});

//				using (var gremlinClient = new GremlinClient(
//											ServerGremlin,
//											new GraphSON2Reader(),
//											new GraphSON2Writer(),
//											GremlinClient.GraphSON2MimeType,
//											connectionPoolSettings,
//											webSocketConfiguration))
//				{
//					foreach (var jump in allJumps)
//					{
//						Console.WriteLine($"Ajout de la relation JUMP de : {jump.FromSystem} vers {jump.ToSystem}");

//						string request = jump.ToQueryAddEdge(); 
//						await gremlinClient.SubmitAsync<dynamic>(request);
//					}
//				}
//			}
//			catch (Exception ex)
//			{
//				Console.WriteLine("ERREUR sur le création des EDGES : " + ex.Message);
//			}
//		}
//	}
//}
