using System;

namespace MathCalculator
{
	public class Calculator
	{
		private Action<TypeLog, string> Logger;

		public Calculator(Action<TypeLog, string> actionLogger)
		{
			Logger = actionLogger;
		}

		public int Addition(int a, int b)
		{
			Log(TypeLog.Info, $"Appel Addition avec : {a} et {b}");

			int resultat = a + b;
			
			Log(TypeLog.Success, $"Résultat {resultat}.");

			return resultat;
		}

		public void MethodWithError(int a, int b)
		{
			try
			{
				Log(TypeLog.Info, $"Appel MethodWithError avec : {a} et {b}");

				throw new Exception("ERREUR levé dans la méthode !!!");
			}
			catch (Exception ex)
			{
				Log(TypeLog.Error, "Exception levé sur la méthode : MethodWithError");
				Log(TypeLog.Error, $"StackTrace : {ex.Message}.");
			}
		}

		public void MethodWithWarn(int leparam)
		{
			try
			{
				Log(TypeLog.Info, $"Appel MethodWithWarn avec comme paramètre : {leparam}");
				Log(TypeLog.Warn, $"!!!!! WARNING {leparam} !!!!!");
			}
			catch (Exception ex)
			{
				Log(TypeLog.Error, "Exception levé sur la méthode : MethodWithWarn");
				Log(TypeLog.Error, $"StackTrace : {ex.Message}.");
			}
		}

		private void Log(TypeLog typeLog, string message)
		{
			Logger?.Invoke(typeLog, message);
		}
	}

	public enum TypeLog
	{
		Error,
		Warn,
		Info,
		Success
	}
}
