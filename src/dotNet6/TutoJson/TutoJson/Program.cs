using System.Text.Encodings.Web;
using System.Text.Unicode;

"######## Début de l'application Démo ########".ToConsoleInfo();
"######## pour JSON en .Net 6         ########".ToConsoleInfo();
"#:> Appuyer sur une touche pour commencer.".ToConsoleInfo();
ReadKey();

"######## Création d'un JSON à la \"main\" ###########".ToConsoleInfo();
"#:> Appuyer sur une touche pour commencer.".ToConsoleInfo();
ReadKey();
WriteLine();

JsonArray incidents = new JsonArray();
for (int id = 1; id <= 10; id++)
{
	JsonObject nouveauIncident = new JsonObject{ ["id"] = id, ["titre"] = $"Problème numéro {id}." };
	incidents.Add(nouveauIncident);
}

// Ajout de tous les incidents dans 
JsonObject jsonIncidents = new JsonObject();
jsonIncidents.Add("description", "Liste des incidents pour un problème");
jsonIncidents.Add("incidents", incidents);

"Retourne l'objet en string, mais non indenté.".ToConsoleInfo();
string contentNonIndente = jsonIncidents.ToJsonString();
contentNonIndente.ToConsoleResult();

WriteLine();
"Faisons en sorte que la sortie en string, soit déjà indenté".ToConsoleInfo();

var options = new JsonSerializerOptions { WriteIndented = true };
string contentIndente = jsonIncidents.ToJsonString(options);
contentIndente.ToConsoleResult();

WriteLine();
"Sauvegarde dans un fichier".ToConsoleInfo();
"#:> Appuyer sur une touche pour commencer.".ToConsoleInfo();
ReadKey();

string pathSave = Path.Combine(AppContext.BaseDirectory, "FileAppend.json");
await File.AppendAllTextAsync(pathSave, contentIndente);

WriteLine();
"######## Fin de l'application Démo ########".ToConsoleInfo();

//\u00E9

public static class ConsoleExtension
{
	public static void ToConsoleInfo(this string message)
	{
		ForegroundColor = ConsoleColor.White;
		WriteLine(message);
	}

	public static void ToConsoleResult(this string message)
	{
		ForegroundColor = ConsoleColor.Green;
		WriteLine(message);
	}
}