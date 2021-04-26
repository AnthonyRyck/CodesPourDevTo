using AppTestLogger.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppTestLogger
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void RadioButton_Checked(object sender, RoutedEventArgs e)
		{
			RadioButton radioButtonTypeInfo = (sender as RadioButton);

			var viewModel = GetViewModel();
			viewModel.StatusLog = radioButtonTypeInfo.Content.ToString();
		}


		private MainViewModel GetViewModel()
		{
			return this.DataContext as MainViewModel;
		}
	}
}
