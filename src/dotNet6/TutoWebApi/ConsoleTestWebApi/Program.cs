using Spectre.Console;
using ApiModels;
using System.Text.Json;

var debutTest = new FigletText("# Début des tests #");
debutTest.Alignment = Justify.Left;
AnsiConsole.Write(debutTest);

AnsiConsole.MarkupLine("[italic]Appuyer sur une touche pour continuer...[/]");
Console.ReadKey();

HttpClient clientHttp = new HttpClient();
string baseAddress = "https://localhost:7005/";


//string testPeronne = await clientHttp.GetStringAsync(baseAddress + "api/personne/all");

//IEnumerable<Personne> personnes = JsonSerializer.Deserialize<IEnumerable<Personne>>(testPeronne);
//foreach (var item in personnes)
//{
//	Console.WriteLine(item.name);
//}

AnsiConsole.WriteLine();
AnsiConsole.MarkupLine("### 1er test - retour d'un [bold][underline]type spécifique[/][/] ###");
AnsiConsole.MarkupLine("[italic]Appuyer sur une touche pour continuer...[/]");
Console.ReadKey();

Guid idPersonSpecific = new Guid("2828cd6b-e7ac-4986-bc59-8931e6e983d0");
HttpResponseMessage resultSpecificType = await clientHttp.GetAsync(baseAddress + $"api/personne/{idPersonSpecific}");
if (resultSpecificType.IsSuccessStatusCode)
{
	AnsiConsole.MarkupLine("[green] Réponse de l'action result en JSON : [/]");
	var result = await resultSpecificType.Content.ReadAsStringAsync();
	AnsiConsole.WriteLine(result);

	AnsiConsole.MarkupLine("===============================================");
	AnsiConsole.MarkupLine("[green] Conversion du JSON en objet Personne : [/]");

	Personne personResult = JsonSerializer.Deserialize<Personne>(result);
	AnsiConsole.WriteLine($"NOM : {personResult.name} - EMAIL : {personResult.email}");
}
else
{
	AnsiConsole.MarkupLine("[red]ERREUR [/] :angry_face:");
}

AnsiConsole.WriteLine();
AnsiConsole.MarkupLine("### 2eme test - utilisation d'un [bold][underline]IActionResult[/][/] ###");
AnsiConsole.MarkupLine("[italic]Appuyer sur une touche pour continuer...[/]");
Console.ReadKey();

try
{
	Guid idPerson = new Guid("2828cd6b-e7ac-4986-bc59-8931e6e983d0");
	HttpResponseMessage resultActionResult = await clientHttp.GetAsync(baseAddress + $"api/personne/iactionresult/{idPerson}");
	resultActionResult.EnsureSuccessStatusCode();

	AnsiConsole.MarkupLine("[green] Réponse de l'action result en JSON : [/]");
	var result = await resultActionResult.Content.ReadAsStringAsync();
	AnsiConsole.WriteLine(result);

	AnsiConsole.MarkupLine("===============================================");
	AnsiConsole.MarkupLine("[green] Conversion du JSON en objet Personne : [/]");

	Personne personResult = JsonSerializer.Deserialize<Personne>(result);
	AnsiConsole.WriteLine($"NOM : {personResult.name} - EMAIL : {personResult.email}");
	
}
catch (Exception)
{
	AnsiConsole.MarkupLine("[red]ERREUR [/] :angry_face:");
}


AnsiConsole.WriteLine();
AnsiConsole.MarkupLine("### 3eme test - utilisation d'un [bold][underline]ActionResult<T>[/][/] ###");
AnsiConsole.MarkupLine("[italic]Appuyer sur une touche pour continuer...[/]");
Console.ReadKey();






AnsiConsole.WriteLine();
var finTest = new FigletText("# Fin des tests #");
finTest.Alignment = Justify.Left;
AnsiConsole.Write(finTest);
Console.ReadKey();