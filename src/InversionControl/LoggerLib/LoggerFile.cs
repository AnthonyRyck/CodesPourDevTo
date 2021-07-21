using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LoggerLib
{
	public class LoggerFile : ISuperLogger
	{
		private readonly string PathLog;

		public LoggerFile(string pathFileLog)
		{
			PathLog = pathFileLog;
		}

		public void LogError(string message)
		{
			string msg = AddDateToMessage(message, "ERROR");
			File.AppendAllText(PathLog, msg);
		}

		public void LogInfo(string message)
		{
			string msg = AddDateToMessage(message, "INFO");
			File.AppendAllText(PathLog, msg);
		}

		public void LogSuccess(string message)
		{
			string msg = AddDateToMessage(message, "SUCCESS");
			File.AppendAllText(PathLog, msg);
		}

		public void LogWarning(string message)
		{
			string msg = AddDateToMessage(message, "WARN");
			File.AppendAllText(PathLog, msg);
		}


		private string AddDateToMessage(string message, string typeLog)
		{
			return typeLog + "-" + DateTime.Now.ToString("g") + "-" + message + Environment.NewLine;
		}
	}
}
