using System.Text.Encodings.Web;
using System.Text.Unicode;

"######## Début de l'application Démo ########".ToConsoleInfo();
"######## pour JSON en .Net 6         ########".ToConsoleInfo();
"#:> Appuyer sur une touche pour commencer.".ToConsoleInfo();
ReadKey();

"######## LECTURE d'un JSON à partir d'objets ###########".ToConsoleInfo();
"#:> Appuyer sur une touche pour commencer.".ToConsoleInfo();
ReadKey();
WriteLine();







"######## CREATION d'un JSON à partir d'objets ###########".ToConsoleInfo();
"#:> Appuyer sur une touche pour commencer.".ToConsoleInfo();
ReadKey();
WriteLine();

List<Incident> incidentsObject = new List<Incident>();
for (int i = 0; i <= 10; i++)
{
	incidentsObject.Add(new Incident() { Id = i, Titre = $"Problème num {i}" });
}

string contentInString = JsonSerializer.Serialize(incidentsObject);

contentInString.ToConsoleResult();
WriteLine();

"Raahhh beurk, ce n'est pas indenté".ToConsoleInfo();
"Faisons en sorte que le JSON soit indenté".ToConsoleInfo();
"#:> Appuyer sur une touche pour commencer.".ToConsoleInfo();
ReadKey();
WriteLine();

JsonSerializerOptions options = new() { WriteIndented = true };
contentInString = JsonSerializer.Serialize(incidentsObject, options);
contentInString.ToConsoleResult();

WriteLine();
"Raahhh encore beurk ! Les caractères avec des accents ne sortent pas comme il faut.".ToConsoleInfo();
"Modifions cela.".ToConsoleInfo();
"#:> Appuyer sur une touche pour commencer.".ToConsoleInfo();
ReadKey();
WriteLine();

JsonSerializerOptions optionSpecial = new()
{
	Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
	WriteIndented = true
};

contentInString = JsonSerializer.Serialize(incidentsObject, optionSpecial);
contentInString.ToConsoleResult();
WriteLine();

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
string contentNonIndente = jsonIncidents.ToJsonString(optionSpecial);
contentNonIndente.ToConsoleResult();

WriteLine();
"Faisons en sorte que la sortie en string, soit déjà indenté".ToConsoleInfo();

string contentIndente = jsonIncidents.ToJsonString(optionSpecial);
contentIndente.ToConsoleResult();

WriteLine();
"Sauvegarde dans un fichier".ToConsoleInfo();
"#:> Appuyer sur une touche pour commencer.".ToConsoleInfo();
ReadKey();

string pathSave = Path.Combine(AppContext.BaseDirectory, "MyJsonFile.json");
await File.AppendAllTextAsync(pathSave, contentIndente);

WriteLine();
"######## Fin de l'application Démo ########".ToConsoleInfo();

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