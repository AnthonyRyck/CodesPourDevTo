using LoggerLib;
using MathCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionControl
{
	public class InteractionUser
	{
		private ISuperLogger Logger;

		public InteractionUser(ISuperLogger logger)
		{
			Logger = logger;
		}


		public void LogMessage(TypeLog typeLog, string message)
		{
			switch (typeLog)
			{
				case TypeLog.Error:
					Logger.LogError(message);
					break;

				case TypeLog.Warn:
					Logger.LogWarning(message);
					break;

				case TypeLog.Info:
					Logger.LogInfo(message);
					break;

				case TypeLog.Success:
					Logger.LogSuccess(message);
					break;

				default:
					Logger.LogError("Euhhh... pas normal d'être là !");
					break;
			}
		}
	}
}
