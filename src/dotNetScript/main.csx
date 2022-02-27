#load "ConsoleExtension.csx"
#r "nuget: AlienFruit.FluentConsole.AsciiArt, 1.0.10"
using AlienFruit.FluentConsole.AsciiArt;
using AlienFruit.FluentConsole;

Console.WriteLine("Le fameux Hello World !");
Console.WriteLine(">Appuyer sur une touche pour continuer.");
Console.ReadKey();

// A partir d'ici, l'appel à Console se fait avec un autre script
Title("Utilisation d'un autre script");
Pause();
Info("Il est possible d'utiliser un autre fichier script en utilisant");
Result("#load \"nomdufichier.csx\"");
SautDeLigne();

Title("Utilisation d'un package Nuget");
Pause();

Info("Il faut utiliser la commande :");
Info("#r \"nuget: nomDuPackage, version\"");
SautDeLigne();
Pause();

Info("Exemple :");
FConsole.GetInstance().DrawDemo(DemoPicture.RainbowPukeSkull);
SautDeLigne();

Info("Voilà, à vos Script !");