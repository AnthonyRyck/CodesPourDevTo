#load "ConsoleExtension.csx"
#r "nuget: AlienFruit.FluentConsole.AsciiArt, 1.0.10"
using AlienFruit.FluentConsole.AsciiArt;
using AlienFruit.FluentConsole;

Console.WriteLine("Le fameux Hello World !");
Console.WriteLine(">Appuyer sur une touche pour continuer.");
Console.ReadKey();

Console.WriteLine("######## Utilisation d'un autre script ########");
Console.WriteLine(">Appuyer sur une touche pour continuer.");
Console.ReadKey();
ConsoleExtension.Info("Il est possible d'utiliser un autre fichier script en utilisant");
ConsoleExtension.Result("#load \"nomdufichier.csx\"");
ConsoleExtension.Espace();

ConsoleExtension.Title("Utilisation d'un package Nuget");
ConsoleExtension.Pause();

ConsoleExtension.Info("Il faut utiliser la commande :");
ConsoleExtension.Info("#r \"nuget: nomDuPackage, version\"");
ConsoleExtension.Espace();
ConsoleExtension.Pause();

ConsoleExtension.Info("Exemple :");
FConsole.GetInstance().DrawDemo(DemoPicture.RainbowPukeSkull);
ConsoleExtension.Espace();

ConsoleExtension.Info("Voilà, à vos Script !");