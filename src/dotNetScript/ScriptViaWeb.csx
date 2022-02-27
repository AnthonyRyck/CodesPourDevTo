#load "ConsoleExtension.csx"
#r "nuget: AlienFruit.FluentConsole.AsciiArt, 1.0.10"
using AlienFruit.FluentConsole.AsciiArt;
using AlienFruit.FluentConsole;

Console.WriteLine("Utilisation d'un script en \"Remote\" !");
Console.WriteLine(">Appuyer sur une touche pour continuer.");
Console.ReadKey();

ConsoleExtension.Info("Exemple :");
FConsole.GetInstance().DrawDemo(DemoPicture.RainbowPukeSkull);
ConsoleExtension.Espace();

ConsoleExtension.Info("Voilà, à vos Script !");