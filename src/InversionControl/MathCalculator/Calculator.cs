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
			Logger?.Invoke(TypeLog.Info, $"Appel Addition avec : {a} et {b}");

			int resultat = a + b;
			
			Logger?.Invoke(TypeLog.Success, $"Résultat {resultat}.");

			return resultat;
		}


		public void MethodWithError(int a, int b)
		{
			try
			{
				Logger?.Invoke(TypeLog.Info, $"Appel MethodWithError avec : {a} et {b}");

				throw new Exception("ERREUR levé dans la méthode !!!");
			}
			catch (Exception ex)
			{
				Logger?.Invoke(TypeLog.Error, "Exception levé sur la méthode : MethodWithError");
				Logger?.Invoke(TypeLog.Error, $"StackTrace : {ex.Message}.");
			}
		}

		public void MethodWithWarn(int leparam)
		{
			try
			{
				Logger?.Invoke(TypeLog.Info, $"Appel MethodWithWarn avec comme paramètre : {leparam}");
				Logger?.Invoke(TypeLog.Warn, $"!!!!! WARNING {leparam} !!!!!");
			}
			catch (Exception ex)
			{
				Logger?.Invoke(TypeLog.Error, "Exception levé sur la méthode : MethodWithWarn");
				Logger?.Invoke(TypeLog.Error, $"StackTrace : {ex.Message}.");
			}
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
