"######## Début de l'application Démo ########".ToConsoleInfo();
"######## pour JSON en .Net 6         ########".ToConsoleInfo();
"#:> Appuyer sur une touche pour commencer.".ToConsoleInfo();
ReadKey();

"######## LECTURE d'un JSON à partir d'un fichier ###########".ToConsoleInfo();
"#:> Appuyer sur une touche pour commencer.".ToConsoleInfo();
ReadKey();
WriteLine();

string pathFile = Path.Combine(AppContext.BaseDirectory, "Files", "personnes.json");
// En utilisant un stream.
using(var stream = File.OpenRead(pathFile))
{
	List<Personne> personnes = await JsonSerializer.DeserializeAsync<List<Personne>>(stream);
	$"Il y a {personnes.Count} personnes dans le fichier.".ToConsoleResult();
}

"######## Requêtes sur JSON ###########".ToConsoleInfo();
"#:> Appuyer sur une touche pour commencer.".ToConsoleInfo();
ReadKey();
WriteLine();

JsonNode jsonNodePerson;
using (var stream = File.OpenRead(pathFile))
{
	jsonNodePerson = JsonObject.Parse(stream);
}
//NOTE : Possible de passer par un string.
//string contentString = File.ReadAllText(pathFile, Encoding.UTF8);

"Pour avoir le nom de la 2eme personne dans le fichier".ToConsoleInfo();
string nomPersonne = jsonNodePerson[1]["name"].GetValue<string>();
$"Nom de la 2eme personne {nomPersonne}".ToConsoleResult();

// avoir valeur de la latitude.
double latitude = jsonNodePerson[1]["latitude"].GetValue<double>();
$"Latitude renseigné : {latitude}".ToConsoleResult();
WriteLine();

// Deserialize ce noeud en objet.
"Deserialize un noeud en objet de type \"Personne\"".ToConsoleInfo();
var unePersonne = jsonNodePerson[1].Deserialize<Personne>();
$"Nom de la 2eme personne {unePersonne.name}".ToConsoleResult();
$"Latitude renseigné : {unePersonne.latitude}".ToConsoleResult();
WriteLine();

"Parcours dans les amis :".ToConsoleInfo();
var jsonFriend = jsonNodePerson[1]["friends"][2].ToJsonString();
$"Affiche un amis de la liste en JSON : {jsonFriend}".ToConsoleResult();
"Parcours dans un ami particulier :".ToConsoleInfo();
string nomAmi = jsonNodePerson[1]["friends"][2]["name"].GetValue<string>();
$"Nom de l'amis : {nomAmi}".ToConsoleResult();
WriteLine();

"Ajout d'une nouvelle propriété pour tout le monde : preference, avec sa valeur".ToConsoleInfo();
"#:> Appuyer sur une touche pour commencer.".ToConsoleInfo();
ReadKey();
JsonArray jsonArray = jsonNodePerson.AsArray();
$"Combien d'élément dans JsonArray : {jsonArray.Count}".ToConsoleResult();
WriteLine();
"Nous allons ajouter une nouvelle propriété dans le JSON".ToConsoleInfo();
for (int i = 0; i < jsonArray.Count; i++)
{
	jsonArray[i]["preference"] = ".Net 6 le meilleur";
}

"Vérification sur une personnne au hasard :".ToConsoleInfo();
Random random = new Random();
jsonArray[random.Next(0, jsonArray.Count)].ToString().ToConsoleResult();
WriteLine();

"Maintenant il faut enlever le genre, propriété gender".ToConsoleInfo();
"#:> Appuyer sur une touche pour commencer.".ToConsoleInfo();
ReadKey();
for (int i = 0; i < jsonArray.Count; i++)
{
	jsonArray[i].AsObject().Remove("gender");
}
"Vérification sur une personnne au hasard :".ToConsoleInfo();
jsonArray[random.Next(0, jsonArray.Count)].ToString().ToConsoleResult();
WriteLine();

"#### Utilisation avec JsonDocument ####".ToConsoleInfo();
"#:> Appuyer sur une touche pour commencer.".ToConsoleInfo();
ReadKey();
"Récupération de tous les noms".ToConsoleInfo();

using (var stream = File.OpenRead(pathFile))
using (JsonDocument document = JsonDocument.Parse(stream))
{
    JsonElement root = document.RootElement;
    var namesPersonne = root.EnumerateArray()
							.Select(x => x.GetProperty("name")
											.GetString())
							.ToList();

	$"Il y a {namesPersonne.Count} noms".ToConsoleResult();

	foreach (var name in namesPersonne.Take(100 .. 110))
    {
		$"- Nom : {name}".ToConsoleResult();
    }

	var personnesSup35ans = root.EnumerateArray()
								.Where(x => x.GetProperty("age").GetInt32() > 35)
								.Select(x => new
								{
									Nom = x.GetProperty("name").GetString(),
									Age = x.GetProperty("age").GetInt32()
								}).ToList();

	$"Il y a {personnesSup35ans.Count} personnes qui ont plus de 35 ans".ToConsoleResult();
	foreach (var person in personnesSup35ans)
	{
		$"- Nom : {person.Nom} - Age : {person.Age}.".ToConsoleResult();
	}
}
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
	JsonObject nouveauIncident = new JsonObject
	{ 
		["id"] = id, 
		["titre"] = $"Problème numéro {id}." 
	};
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