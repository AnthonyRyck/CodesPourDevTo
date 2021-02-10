using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp.Codes
{
	public class DelegateCommand : ICommand
	{
		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			//throw new NotImplementedException();
			return true;
		}

		public void Execute(object parameter)
		{
			_action.Invoke();
		}



		public DelegateCommand(Action action)
		{
			_action = action;
		}



		private Action _action;
	}
}
