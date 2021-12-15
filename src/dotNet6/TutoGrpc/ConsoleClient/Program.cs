using Grpc.Net.Client;
using ClientGrpc;
using System.Diagnostics;
using System.Text.Json;

const string BASE_ADDRESS = "https://localhost:7222";

"##### Début de l'application de test #####".ToConsoleInfo();
"Appuyer sur une touche pour continuer".ToConsoleInfo();
ReadKey();

":> Connexion au serveur.".ToConsoleInfo();
var channel = GrpcChannel.ForAddress(BASE_ADDRESS, new GrpcChannelOptions
{
    MaxReceiveMessageSize = null
});
var client = new Utilisateurs.UtilisateursClient(channel);

":> Récupération du nombre d'utilisateur".ToConsoleInfo();
"Appuyer sur une touche pour continuer".ToConsoleInfo();
ReadKey();
Empty empty = new Empty();
CountUser countUser = await client.GetCountUserAsync(empty);
$"Nombre d'utilisateurs : {countUser.NombreUser}".ToConsoleResult();
WriteLine();

":> Récupération d'un utilisateur avec son ID".ToConsoleInfo();
"Appuyer sur une touche pour continuer".ToConsoleInfo();
ReadKey();
string idUser = "61b6c9ce2ad8b28e03238b33";
var user = await client.GetUserByIdAsync(new UserIdRequest() { IdUser = idUser });
"Récupération de l'utilisateur OK".ToConsoleResult();
"Appuyer sur une touche pour voir le résultat".ToConsoleInfo();
ReadKey();
user.ToString().ToConsoleInfo();
WriteLine();

var chrono = new Stopwatch();

":> Récupération de tous les clients via Controller".ToConsoleInfo();
"Appuyer sur une touche pour continuer".ToConsoleInfo();
ReadKey();
chrono.Start(); 

HttpClient httpClient = new HttpClient();
HttpResponseMessage resultController = await httpClient.GetAsync(BASE_ADDRESS + "/api/tutogrpcusers/all");
using(Stream reponse = await resultController.Content.ReadAsStreamAsync())
{
    var tousLesUtilisateurs = JsonSerializer.DeserializeAsync<List<User>>(reponse);
}

chrono.Stop();
var timeController = chrono.ElapsedMilliseconds;
$"Récupération OK en {timeController} millisecondes".ToConsoleResult();

":> Récupération de tous les clients via gRPC".ToConsoleInfo();
"Appuyer sur une touche pour continuer".ToConsoleInfo();
ReadKey();

chrono.Restart();
var allClients = await client.GetAllAsync(empty);
chrono.Stop();
var timeGrpc = chrono.ElapsedMilliseconds;

$"Récupération OK en {timeGrpc} millisecondes".ToConsoleResult();
":> Comparaison entre le nombre de client reçu et toute la liste.".ToConsoleInfo();
$"--> Compteur à {countUser.NombreUser} et nombre dans la liste : {allClients.AllUsers.Count}".ToConsoleInfo();
WriteLine();

$"--> DIFFERENCE entre le temps gRPC et Controller : {timeGrpc} - {timeController} = {timeGrpc - timeController} milliseconds".ToConsoleInfo();
WriteLine();

"##### Fin de l'application de test #####".ToConsoleInfo();
ReadKey();
