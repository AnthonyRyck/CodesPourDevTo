using System.Text.Json;
using Spectre.Console;


 // Image pour le logo
var logo = new CanvasImage("testlogo.jpg");
AnsiConsole.Write(logo);
AnsiConsole.WriteLine();

// Sous titre
var sousTitre = new FigletText("Partager du code")
					.RightAligned()
					.Color(Color.White);
AnsiConsole.Write(sousTitre);

// Affichage des 10 derniers articles du blog.
Markup markup = new Markup("");

List<PostWordPress> posts = new List<PostWordPress>();

await AnsiConsole.Status()
    		.StartAsync("Récupération des 10 derniers post...", async ctx => 
    		{
				using(var client = new HttpClient())
				{
					string url = @"https://www.ctrl-alt-suppr.dev/wp-json/wp/v2/posts?per_page=10";
					var streamPosts = await client.GetStreamAsync(url);
					posts = await JsonSerializer.DeserializeAsync<List<PostWordPress>>(streamPosts);
				}
				// Si ça va trop vite pour la récupération
				await Task.Delay(2000);
				AnsiConsole.MarkupLine("Terminé");
    		});

// Affichage des posts.
for (var i = 0; i < posts.Count; i++)
{
	AnsiConsole.MarkupLine($"{i + 1} - {posts[i].title.rendered}");
}

AnsiConsole.Write("FIN");
Console.ReadKey();

// Markup ShowMarkup()
// {
// 	 return new Markup(
//             "[bold fuchsia]/help[/]: Shows this [underline green]help[/] text.\n"
//             + "[bold fuchsia]/user[/] [aqua]<username>[/]: Switches to the specified [underline green]user[/] account.\n"
//             + "[bold fuchsia]/chirp[/] [aqua]<message>[/]: [underline green]Chirps[/] a [aqua]message[/] from the active account.\n"
//             + "[bold fuchsia]/follow[/] [aqua]<username>[/]: [underline green]Follows[/] the account with the specified [aqua]username[/].\n"
//             + "[bold fuchsia]/unfollow[/] [aqua]<username>[/]: [underline green]Unfollows[/] the account with the specified [aqua]username[/].\n"
//             + "[bold fuchsia]/following[/]: Lists the accounts that the active account is [underline green]following[/].\n"
//             + "[bold fuchsia]/followers[/]: Lists the accounts [underline green]followers[/] the active account.\n"
//             + "[bold fuchsia]/observe[/]: [underline green]Start observing[/] the active account.\n"
//             + "[bold fuchsia]/unobserve[/]: [underline green]Stop observing[/] the active account.\n"
//             + "[bold fuchsia]/quit[/]: Closes this client.\n");
// }