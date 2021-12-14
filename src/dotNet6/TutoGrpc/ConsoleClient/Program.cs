using Grpc.Net.Client;
using ClientGrpc;
using System.Diagnostics;

"##### Début de l'application de test #####".ToConsoleInfo();

":> Connexion au serveur.".ToConsoleInfo();
var channel = GrpcChannel.ForAddress("https://localhost:7222");
var client = new Utilisateurs.UtilisateursClient(channel);

":> Récupération du nombre d'utilisateur".ToConsoleInfo();
"Appuyer sur une touche pour continuer".ToConsoleInfo();
ReadKey();
Empty empty = new Empty();
CountUser countUser = await client.GetCountUserAsync(empty);
$"Nombre d'utilisateurs : {countUser.NombreUser}".ToConsoleResult();
WriteLine();

":> Récupération de tous les clients".ToConsoleInfo();
"Appuyer sur une touche pour continuer".ToConsoleInfo();
ReadKey();

var chrono = new Stopwatch();
chrono.Start();
var allClients = await client.GetAllAsync(empty);
chrono.Stop();

$"Récupération OK en {chrono.ElapsedMilliseconds} millisecondes".ToConsoleResult();
":> Comparaison entre le nombre de client reçu et toute la liste.".ToConsoleInfo();
$"--> Compteur à {countUser.NombreUser} et nombre dans la liste : {allClients.AllUsers.Count}".ToConsoleInfo();
WriteLine();

":> Récupération d'un utilisateur avec son ID".ToConsoleInfo();
"Appuyer sur une touche pour continuer".ToConsoleInfo();
ReadKey();
string idUser = "61b6c9ce2ad8b28e03238b33";
var user = await client.GetUserByIdAsync(new UserIdRequest(){ IdUser = idUser });
"Récupération de l'utilisateur OK".ToConsoleResult();
"Appuyer sur une touche pour voir le résultat".ToConsoleInfo();
ReadKey();
user.ToString().ToConsoleInfo();
WriteLine();

"##### Fin de l'application de test #####".ToConsoleInfo();
ReadKey();
