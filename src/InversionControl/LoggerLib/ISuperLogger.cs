using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerLib
{
	public interface ISuperLogger
	{
		/// <summary>
		/// Log un message d'information
		/// </summary>
		/// <param name="message"></param>
		void LogInfo(string message);

		/// <summary>
		/// Log une erreur avec son exception
		/// </summary>
		/// <param name="messageError"></param>
		void LogError(string messageError);

		/// <summary>
		/// Log un message d'attention
		/// </summary>
		/// <param name="messageWarn"></param>
		void LogWarning(string messageWarn);

		/// <summary>
		/// Log d'un message de "succés".
		/// </summary>
		/// <param name="messageSuccess"></param>
		void LogSuccess(string messageSuccess);
	}
}
