using System.Text.Json;
using Spectre.Console;
using System.Diagnostics;

// Image pour le logo
var logo = new CanvasImage("logo.jpg");
AnsiConsole.Write(logo);
AnsiConsole.WriteLine();

// Slogan
var slogan = new FigletText("Partager du code")
					.RightAligned()
					.Color(Color.White);
AnsiConsole.Write(slogan);

// Affichage des 10 derniers articles du blog.
List<PostWordPress> posts = new List<PostWordPress>();

await AnsiConsole.Status()
    		.StartAsync("Récupération des 10 derniers post...", async ctx => 
    		{
				// Change le "waiting".
				ctx.Spinner(Spinner.Known.Aesthetic);

				using(var client = new HttpClient())
				{
					string url = @"https://www.ctrl-alt-suppr.dev/wp-json/wp/v2/posts?per_page=10";
					var streamPosts = await client.GetStreamAsync(url);
					posts = await JsonSerializer.DeserializeAsync<List<PostWordPress>>(streamPosts);
				}
				// Pour avoir le temps de voir le "waiting".
				await Task.Delay(5000);
				AnsiConsole.MarkupLine(":check_mark: Terminé " + Emoji.Known.CheckMark);
    		});

string cmdQuit = "quit";
string selection = string.Empty;

ShowPosts();

while(selection != cmdQuit)
{
	AnsiConsole.WriteLine();
	selection = AnsiConsole.Ask<string>("Quel est votre choix ?");

	switch (selection)
	{
		case "quit":
			AnsiConsole.WriteLine();
			AnsiConsole.MarkupLine("See you soon " + Emoji.Known.OkHand);
			AnsiConsole.WriteLine();
			Environment.Exit(0);
			break;
		case "posts":
			ShowPosts();
			break;
		case "1":
		case "2":
		case "3":
		case "4":
		case "5":
		case "6":
		case "7":
		case "8":
		case "9":
		case "10":
			int index = int.Parse(selection);
			string urlPost = posts[index - 1].link;
			try
			{
				ProcessStartInfo startInfo = new ProcessStartInfo(@"C:\Program Files (x86)\Microsoft\Edge\Applicatio\msedge.exe");
            	startInfo.WindowStyle = ProcessWindowStyle.Maximized;
            	startInfo.Arguments = urlPost;
            	Process.Start(startInfo);
				
				AnsiConsole.MarkupLine("[green]Bonne lecture[/] :grinning_face_with_big_eyes:");
			}
			catch (System.Exception ex)
			{
				AnsiConsole.MarkupLine("[red]ERREUR [/] :angry_face:");
				AnsiConsole.MarkupLine("Edge n'a pas pu être ouvert, du coup voici l'URL de l'article choisi :");
				AnsiConsole.MarkupLine(urlPost);
			}
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
		AnsiConsole.MarkupLine($"[purple]{i + 1}[/] - {posts[i].date.ToString("d")} - {posts[i].title.rendered}");
	}
	AnsiConsole.MarkupLine("[green]posts[/] : pour réafficher la liste des articles.");
	AnsiConsole.MarkupLine("[red]quit[/] : pour quitter.");
}