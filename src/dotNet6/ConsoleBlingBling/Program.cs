using System.Text.Json;
using Spectre.Console;
using System.Diagnostics;

// Image pour le logo
var logo = new CanvasImage("logo.jpg");
AnsiConsole.Write(logo);
AnsiConsole.WriteLine();

// Sous titre
var sousTitre = new FigletText("Partager du code")
					.RightAligned()
					.Color(Color.White);
AnsiConsole.Write(sousTitre);

// Affichage des 10 derniers articles du blog.
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
				await Task.Delay(5000);
				AnsiConsole.MarkupLine("Terminé");
    		});

string cmdQuit = "/quit";
string selection = string.Empty;

ShowPosts();

while(selection != cmdQuit)
{
	selection = AnsiConsole.Ask<string>("Quel est votre choix ?");

	switch (selection)
	{
		case "/quit":
			Environment.Exit(0);
			break;
		case "/posts":
			ShowPosts();
			break;
		case "/post1":
		case "/post2":
		case "/post3":
		case "/post4":
		case "/post5":
		case "/post6":
		case "/post7":
		case "/post8":
		case "/post9":
		case "/post10":
			int index = int.Parse(selection.Replace("/post", string.Empty));
			string urlPost = posts[index - 1].link;
			AnsiConsole.MarkupLine("[green]Bonne lecture[/] :grinning_face_with_big_eyes:");

			ProcessStartInfo startInfo = new ProcessStartInfo(@"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe");
            startInfo.WindowStyle = ProcessWindowStyle.Maximized;
            startInfo.Arguments = urlPost;
            Process.Start(startInfo);
			break;
		default:
			AnsiConsole.MarkupLine("[red]Euuhhh le choix n'est pas compliqué...[/] :angry_face:");
			AnsiConsole.MarkupLine(string.Empty);
			break;
	}
}

void ShowPosts()
{
	// Affichage des posts.
	for (var i = 0; i < posts.Count; i++)
	{
		AnsiConsole.MarkupLine($"/post{i + 1} - {posts[i].title.rendered}");
	}
	AnsiConsole.MarkupLine("/posts : pour réafficher la liste des articles.");
	AnsiConsole.MarkupLine("/quit : pour quitter.");
}