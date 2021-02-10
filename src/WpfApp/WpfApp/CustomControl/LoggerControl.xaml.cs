using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
using WpfApp.Codes;

namespace WpfApp.CustomControl
{
    /// <summary>
    /// Interaction logic for LoggerControl.xaml
    /// </summary>
    public partial class LoggerControl : UserControl
    {
        public LoggerControl()
        {
            InitializeComponent();
        }

        #region DependencyProperty

        public ObservableCollection<LogInfo> AllLogs
        {
            get { return (ObservableCollection<LogInfo>)GetValue(AllLogsProperty); }
            set { SetValue(AllLogsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AllLogs.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AllLogsProperty =
            DependencyProperty.Register("AllLogs",
                                        typeof(ObservableCollection<LogInfo>),
                                        typeof(LoggerControl),
                                        new PropertyMetadata(new ObservableCollection<LogInfo>(),
                                            OnAllLogsChanged));

        private static void OnAllLogsChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            LoggerControl loggerControl = sender as LoggerControl;
            var old = e.OldValue as ObservableCollection<LogInfo>;

            if (old != null)
            {
                old.CollectionChanged -= loggerControl.OnWorkCollectionChanged;
            }

            var nouvelleValeur = e.NewValue as ObservableCollection<LogInfo>;

            if (nouvelleValeur != null)
            {
                nouvelleValeur.CollectionChanged += loggerControl.OnWorkCollectionChanged;
            }

            // Reset de la liste.
            if (old.Count > 0 && nouvelleValeur.Count == 0)

                loggerControl.FlowDoc.Blocks.Clear();
        }

        /// <summary>
        /// Méthode quand la collection est modifiée.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWorkCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                // Clear and update entire collection
                this.FlowDoc.Blocks.Clear();
            }

            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                var nouvelleCollection = sender as ObservableCollection<LogInfo>;

                LogInfo derniereLigne = nouvelleCollection.Last();

                Paragraph paragraphLog = new Paragraph(new Run(derniereLigne.InformationMessage));
                paragraphLog.Margin = new Thickness(0, 0, 0, 0);

                switch (derniereLigne.StatusLog)
                {

                    case StatusLog.Error:
                        paragraphLog.Foreground = Brushes.Red;
                        break;
                    case StatusLog.Warn:
                        paragraphLog.Foreground = Brushes.Orange;
                        break;
                    case StatusLog.InfoGreen:
                        paragraphLog.Foreground = Brushes.Green;
                        break;
                    case StatusLog.Information:
                    default:
                        paragraphLog.Foreground = Brushes.Black;
                        break;
                }

                this.FlowDoc.Blocks.Add(paragraphLog);
                this.RichText.ScrollToEnd();

            }
        }

		#endregion

	}
}