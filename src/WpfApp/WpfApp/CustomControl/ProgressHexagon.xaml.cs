using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp.CustomControl
{
    public partial class ProgressHexagon : UserControl, INotifyPropertyChanged
    {
        private const double RATIO = 0.78d;

        #region Properties

        /// <summary>
        /// Donne translation X pour le composant.
        /// </summary>
        public double TranslationDroite
        {
            get { return _translationDroite; }
            set
            {
                if (value != _translationDroite)
                {
                    _translationDroite = value;
                    OnPropertyChanged();
                }
            }
        }
        private double _translationDroite;

        /// <summary>
        /// Translation X pour la Gauche
        /// </summary>
        public double TranslationGauche
        {
            get { return _translationGauche; }
            set
            {
                if (value != _translationGauche)
                {
                    _translationGauche = value;
                    OnPropertyChanged();
                }
            }
        }
        private double _translationGauche;

        /// <summary>
        /// Translation Bas Droite pour X
        /// </summary>
        public double TranslationBasDroite
        {
            get { return _translationBasDroite; }
            set
            {
                if (value != _translationBasDroite)
                {
                    _translationBasDroite = value;
                    OnPropertyChanged();
                }
            }
        }
        private double _translationBasDroite;

        /// <summary>
        /// Translation X sur Bas Gauche
        /// </summary>
        public double TranslationBasGauche
        {
            get { return _translationBasGauche; }
            set
            {
                if (value != _translationBasGauche)
                {
                    _translationBasGauche = value;
                    OnPropertyChanged();
                }
            }
        }
        private double _translationBasGauche;

        /// <summary>
        /// Translation sur Y Haut Gauche
        /// </summary>
        public double TranslationHautGaucheSurY
        {
            get { return _translationHautGaucheSurY; }
            set
            {
                if (value != _translationHautGaucheSurY)
                {
                    _translationHautGaucheSurY = value;
                    OnPropertyChanged();
                }
            }
        }
        private double _translationHautGaucheSurY;

        /// <summary>
        /// Translation sur Y en négatif.
        /// </summary>
        public double TranslationEnNegatifSurY
        {
            get { return _translationEnNegatifSurY; }
            set
            {
                if (value != _translationEnNegatifSurY)
                {
                    _translationEnNegatifSurY = value;
                    OnPropertyChanged();
                }
            }
        }
        private double _translationEnNegatifSurY;

        /// <summary>
        /// Largeur du control
        /// </summary>
        public double WidthControl
        {
            get { return _widthControl; }
            set
            {
                if (value != _widthControl)
                {
                    _widthControl = value;
                    OnPropertyChanged();
                }
            }
        }

        private double _widthControl;

        /// <summary>
        /// Hauteur du control
        /// </summary>
        public double HeightControl
        {
            get { return _heightControl; }
            set
            {
                if(value != _heightControl)
                {
                    _heightControl = value;
                    OnPropertyChanged();
                }
            }
        }

        private double _heightControl;

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public ProgressHexagon()
        {
            InitializeComponent();
        }

        #region Dependencies Properties - Couleur

        public static readonly DependencyProperty ColorHexagonProperty = DependencyProperty.Register(
            "ColorHexagon", typeof(Brush), typeof(ProgressHexagon), new PropertyMetadata(default(Brush)));

        public Brush ColorHexagon
        {
            get { return (Brush)GetValue(ColorHexagonProperty); }
            set { SetValue(ColorHexagonProperty, value); }
        }

        #endregion

        #region Dependencies Properties - Taille

        public static readonly DependencyProperty SizeProperty = DependencyProperty.Register(
            "Size", typeof(double), typeof(ProgressHexagon), new PropertyMetadata(default(double)));

        public double Size
        {
            get { return (double)GetValue(SizeProperty); }
            set { SetValue(SizeProperty, value); }
        }

        #endregion

        private void ProgressHexagon_OnLoaded(object sender, RoutedEventArgs e)
        {
            CalculateTranslation();
            //StoryboardProgress.Begin();
        }

        private void CalculateTranslation()
        {
            TranslationDroite = Size + 1;
            TranslationGauche = -(Size + 1);
            TranslationBasDroite = -((Size / 2) + 0.5d);
            TranslationBasGauche = (Size / 2) + 0.5d;

            TranslationHautGaucheSurY = Size * RATIO;
            TranslationEnNegatifSurY = -(Size * RATIO);

            WidthControl = 3 * Size + 2;

            var ratioHeight = 129d / 152d;

            HeightControl = WidthControl * ratioHeight;
        }


        #region Implement INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string memberName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(memberName));
            }
        }

        #endregion

    }
}
