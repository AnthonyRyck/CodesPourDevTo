#r "nuget: Spectre.Console, 0.43.0"
#r "nuget: Spectre.Console.ImageSharp, 0.43.0"

using System.Net.Http;
using System.Text.Json;
using Spectre.Console;


// Image pour le logo
// Téléchargement de l'image sur Git
using(var clientImg = new HttpClient())
{
	string url = @"https://raw.githubusercontent.com/AnthonyRyck/CodesPourDevTo/master/src/dotNet6/ConsoleBlingBling/logo.jpg";
	var streamImg = await clientImg.GetStreamAsync(url);
	
	var logo = new CanvasImage(streamImg);
	AnsiConsole.Write(logo);
	AnsiConsole.WriteLine();
}

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
				await Task.Delay(10000);
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
			System.Diagnostics.Process.Start(urlPost);
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



#region Entities


    public class Guid
    {
        public string rendered { get; set; }
    }

    public class Title
    {
        public string rendered { get; set; }
    }

    public class Content
    {
        public string rendered { get; set; }
        public bool @protected { get; set; }
    }

    public class Excerpt
    {
        public string rendered { get; set; }
        public bool @protected { get; set; }
    }

    public class Meta
    {
        public string neve_meta_sidebar { get; set; }
        public string neve_meta_container { get; set; }
        public string neve_meta_enable_content_width { get; set; }
        public int neve_meta_content_width { get; set; }
        public string neve_meta_title_alignment { get; set; }
        public string neve_meta_author_avatar { get; set; }
        public string neve_post_elements_order { get; set; }
        public string neve_meta_disable_header { get; set; }
        public string neve_meta_disable_footer { get; set; }
        public string neve_meta_disable_title { get; set; }
    }

    public class Self
    {
        public string href { get; set; }
    }

    public class Collection
    {
        public string href { get; set; }
    }

    public class About
    {
        public string href { get; set; }
    }

    public class Author
    {
        public bool embeddable { get; set; }
        public string href { get; set; }
    }

    public class Reply
    {
        public bool embeddable { get; set; }
        public string href { get; set; }
    }

    public class VersionHistory
    {
        public int count { get; set; }
        public string href { get; set; }
    }

    public class PredecessorVersion
    {
        public int id { get; set; }
        public string href { get; set; }
    }

    public class WpFeaturedmedia
    {
        public bool embeddable { get; set; }
        public string href { get; set; }
    }

    public class WpAttachment
    {
        public string href { get; set; }
    }

    public class WpTerm
    {
        public string taxonomy { get; set; }
        public bool embeddable { get; set; }
        public string href { get; set; }
    }

    public class Cury
    {
        public string name { get; set; }
        public string href { get; set; }
        public bool templated { get; set; }
    }

    public class Links
    {
        public List<Self> self { get; set; }
        public List<Collection> collection { get; set; }
        public List<About> about { get; set; }
        public List<Author> author { get; set; }
        public List<Reply> replies { get; set; }
        public List<VersionHistory> VersionHistory { get; set; }
        public List<PredecessorVersion> PredecessorVersion { get; set; }

        public List<WpFeaturedmedia> WpFeaturedmedia { get; set; }
        public List<WpAttachment> WpAttachment { get; set; }
		public List<WpTerm> WpTerm { get; set; }
        public List<Cury> curies { get; set; }
    }

    public class PostWordPress
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public DateTime date_gmt { get; set; }
        public Guid guid { get; set; }
        public DateTime modified { get; set; }
        public DateTime modified_gmt { get; set; }
        public string slug { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public string link { get; set; }
        public Title title { get; set; }
        public Content content { get; set; }
        public Excerpt excerpt { get; set; }
        public int author { get; set; }
        public int featured_media { get; set; }
        public string comment_status { get; set; }
        public string ping_status { get; set; }
        public bool sticky { get; set; }
        public string template { get; set; }
        public string format { get; set; }
        public Meta meta { get; set; }
        public List<int> categories { get; set; }
        public List<int> tags { get; set; }
        public Links _links { get; set; }
    }



#endregion