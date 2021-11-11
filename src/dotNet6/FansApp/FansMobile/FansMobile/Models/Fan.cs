using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace FansMobile.Models
{
	public class Fan : INotifyPropertyChanged
	{
		/// <summary>
		/// ID du Fan.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Nom du fan
		/// </summary>
		public string Nom { get; set; }

		/// <summary>
		/// Nombre de clique reçu
		/// </summary>
		public int NombreDeClickRecu
		{
			get { return _nombreDeClickRecu; }
			set
			{
				_nombreDeClickRecu = value;
				OnNotifyPropertyChanged();
			}
		}
		private int _nombreDeClickRecu;

		/// <summary>
		/// Autres informations sur le fan.
		/// </summary>
		public string InfoDiverses { get; set; }

		/// <summary>
		/// Date d'inscription du fan
		/// </summary>
		public DateTime DateInscription { get; set; }


		#region INotifyPropertyChanged

		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnNotifyPropertyChanged([CallerMemberName] string propertyName = "")
		{
			var changed = PropertyChanged;
			if (changed == null)
				return;

			changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		#endregion
	}
}
