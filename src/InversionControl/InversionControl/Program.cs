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
			Console.WriteLine("En passant une expression lambda.");
			Action<TypeLog, string> actionLog = (TypeLog type, string message) =>
			{
				switch (type)
				{
					case TypeLog.Error:
						Console.WriteLine("ERROR-" + message);
						break;

					case TypeLog.Warn:
						Console.WriteLine("WARN-" + message);
						break;

					case TypeLog.Info:
						Console.WriteLine("INFO-" + message);
						break;

					case TypeLog.Success:
						Console.WriteLine("SUCCESS-" + message);
						break;

					default:
						Console.WriteLine("Euhhh... pas normal d'être là !");
						break;
				}
			};
			Calculator calculLambda = new Calculator(actionLog);
			calculLambda.Addition(3, 4);
			Console.WriteLine("------------");
			calculLambda.MethodWithError(1, 2);
			calculLambda.MethodWithWarn(54);


			Console.WriteLine("##### Autre manière ######");
			Console.WriteLine("En passant par une class un peu plus élaborée.");

			InteractionUser user = new InteractionUser(new LoggerConsole());
			Calculator calculator = new Calculator(user.LogMessage);
			calculator.Addition(3, 4);
			user.LogMessage(TypeLog.Info, "------------");
			calculator.MethodWithError(1, 2);
			calculator.MethodWithWarn(54);

			Console.WriteLine("##################");
			Console.WriteLine("Les logs sont dans un fichier.");

			InteractionUser userFile = new InteractionUser(new LoggerFile(@"c:\123\log.txt"));

			Calculator calculatorFile = new Calculator(userFile.LogMessage);
			calculatorFile.Addition(3, 4);
			userFile.LogMessage(TypeLog.Info, "------------");
			calculatorFile.MethodWithError(1, 2);
			calculatorFile.MethodWithWarn(54);

			Console.WriteLine("#### Fin de l'application ####");
		}
	}
}
