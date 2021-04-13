using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RichLogger
{
    public class LogInfo
    {
        /// <summary>
        /// Indique le type d'information.
        /// </summary>
        public StatusLog StatusLog { get; set; }

        /// <summary>
        /// Contient le message de l'information
        /// </summary>
        public string InformationMessage { get; set; }

        public LogInfo(StatusLog type, string message)
        {
            StatusLog = type;
            InformationMessage = message;
        }
    }



    public enum StatusLog
    {
        Error,
        Information,
        Warn,
        InfoGreen
    }
}
