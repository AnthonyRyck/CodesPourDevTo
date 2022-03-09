using System.Reflection;
using Spectre.Console;

 // Image pour Ctrl-Alt-Suppr
var logo = new CanvasImage("testlogo.jpg");
AnsiConsole.Write(logo);

// Création du tableau
// var tableLauch = new Table
// {
//     Border = TableBorder.None,
//     Expand = true,
// }.HideHeaders();

// tableLauch.AddColumn(new TableColumn("logo"));
// tableLauch.AddRow()

AnsiConsole.WriteLine();

// Sous titre
var sousTitre = new FigletText("Partager du code")
					.RightAligned()
					.Color(Color.White);
AnsiConsole.Write(sousTitre);



AnsiConsole.Write("FIN");
Console.ReadKey();

Markup ShowMarkup()
{
	 return new Markup(
            "[bold fuchsia]/help[/]: Shows this [underline green]help[/] text.\n"
            + "[bold fuchsia]/user[/] [aqua]<username>[/]: Switches to the specified [underline green]user[/] account.\n"
            + "[bold fuchsia]/chirp[/] [aqua]<message>[/]: [underline green]Chirps[/] a [aqua]message[/] from the active account.\n"
            + "[bold fuchsia]/follow[/] [aqua]<username>[/]: [underline green]Follows[/] the account with the specified [aqua]username[/].\n"
            + "[bold fuchsia]/unfollow[/] [aqua]<username>[/]: [underline green]Unfollows[/] the account with the specified [aqua]username[/].\n"
            + "[bold fuchsia]/following[/]: Lists the accounts that the active account is [underline green]following[/].\n"
            + "[bold fuchsia]/followers[/]: Lists the accounts [underline green]followers[/] the active account.\n"
            + "[bold fuchsia]/observe[/]: [underline green]Start observing[/] the active account.\n"
            + "[bold fuchsia]/unobserve[/]: [underline green]Stop observing[/] the active account.\n"
            + "[bold fuchsia]/quit[/]: Closes this client.\n");
}