using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp.Codes;

namespace WpfApp.ViewModel
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

            StartStopClick = new DelegateCommand(StartStop);
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


        private void StartStop()
		{
            if(Loading == Visibility.Visible)
            {
                Loading = Visibility.Hidden;
            }
			else
			{
                Loading = Visibility.Visible;
			}

        }

    }
}
