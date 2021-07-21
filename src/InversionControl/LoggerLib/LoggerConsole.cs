using System;

namespace LoggerLib
{
	public class LoggerConsole : ISuperLogger
	{
		public void LogError(string messageError)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(messageError);
			Console.ForegroundColor = ConsoleColor.Gray;
		}

		public void LogInfo(string message)
		{
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine(message);
			Console.ForegroundColor = ConsoleColor.Gray;
		}

		public void LogWarning(string messageWarn)
		{
			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.WriteLine(messageWarn);
			Console.ForegroundColor = ConsoleColor.Gray;
		}

		public void LogSuccess(string messageSuccess)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine(messageSuccess);
			Console.ForegroundColor = ConsoleColor.Gray;
		}
	}
}
