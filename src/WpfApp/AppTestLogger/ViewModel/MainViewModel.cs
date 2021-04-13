using System.Windows;
using System.Windows.Input;
using AppTestLogger.Codes;

namespace AppTestLogger.ViewModel
{
	public class MainViewModel : BaseViewModel
    {
        /// <summary>
        /// Message à mettre dans les logs.
        /// </summary>
        public string MessageToLog { get; set; }

		public string StatusLog { get; set; }

		public ICommand AddLogsClick { get; private set; }


        public ICommand StartStopClick { get; private set; }


		public MainViewModel()
		{
            AddLogsClick = new DelegateCommand(AddMessageToLog);
        }


		private void AddMessageToLog()
		{
			switch (StatusLog)
			{
                case "Error":
                    LogError(MessageToLog);
                    break;

                case "Info":
                    LogInformation(MessageToLog);
                    break;

                case "Warning":
                    LogWarning(MessageToLog);
                    break;

                case "Success":
                    LogSuccess(MessageToLog);
                    break;

                default:
                    LogInformation(MessageToLog);
                    break;
			}
                        
        }


    }
}
