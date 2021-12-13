using Grpc.Net.Client;
using ClientGrpc;


Console.WriteLine("##### Début de l'application de test #####");

var channel = GrpcChannel.ForAddress("https://localhost:7222");
var client = new Utilisateurs.UtilisateursClient(channel);

Empty empty = new Empty();
CountUser countUser = await client.GetCountUserAsync(empty);

Console.WriteLine($"Nombre d'utilisateurs : {countUser.NombreUser}");

Console.WriteLine("##### Fin de l'application de test #####");
Console.ReadKey();
