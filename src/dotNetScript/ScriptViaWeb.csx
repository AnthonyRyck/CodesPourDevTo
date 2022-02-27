#load "nuget:ConsoleExtensionScript , 1.0.0"
#r "nuget: AlienFruit.FluentConsole.AsciiArt, 1.0.10"
using AlienFruit.FluentConsole.AsciiArt;
using AlienFruit.FluentConsole;

// Console.WriteLine("Utilisation d'un script en \"Remote\" !");
// Console.WriteLine(">Appuyer sur une touche pour continuer.");
// Console.ReadKey();

Info("Utilisation d'un script en \"Remote\" !");
Pause();

Info("Exemple :");
FConsole.GetInstance().DrawDemo(DemoPicture.Punisher);
SautDeLigne();

Info("Voilà, à vos Script !");
Pause();