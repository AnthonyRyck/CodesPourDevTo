using System;
using LoggerLib;
using MathCalculator;

namespace InversionControl
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("#### Début de l'application ####");

			Console.WriteLine("Les logs sont dans la Console.");
			InteractionUser user = new InteractionUser(new LoggerConsole());

			Calculator calculator = new Calculator(user.LogMessage);
			var resultat = calculator.Addition(3, 4);

			user.LogMessage(TypeLog.Info, "------------");

			calculator.MethodWithError(1, 2);
			calculator.MethodWithWarn(54);

			Console.WriteLine("##################");
			Console.WriteLine("Les logs sont dans un fichier.");

			InteractionUser userFile = new InteractionUser(new LoggerFile(@"c:\123\log.txt"));

			Calculator calculatorFile = new Calculator(userFile.LogMessage);
			var resultatFile = calculatorFile.Addition(3, 4);

			userFile.LogMessage(TypeLog.Info, "------------");

			calculatorFile.MethodWithError(1, 2);
			calculatorFile.MethodWithWarn(54);

			Console.WriteLine("#### Fin de l'application ####");
		}




	}
}
