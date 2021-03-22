using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;

namespace FansMobile.Models
{
	public class FanWithValidation : INotifyPropertyChanged
	{
		[Required(AllowEmptyStrings = false, ErrorMessage = "Il faut un nom !")]
		[StringLength(10, MinimumLength = 4, ErrorMessage = "Il faut un nom de Fan avec au moins 4 caractères et max 10.")]
		public string NomFan
		{
			get { return _nomFan; }
			set
			{
				ErrorMsgNomFan = ValidateProperty(value, "NomFan");
				_nomFan = value;

				IsNameError = ErrorMsgNomFan != null;
				OnNotifyPropertyChanged("HasErrors");
			}
		}
		private string _nomFan;

		[Required(AllowEmptyStrings = false, ErrorMessage = "Aller, une petite info")]
		[StringLength(30, ErrorMessage = "Ooh doucement, c'est pas un magazine people ici.")]
		public string InfoDiverses
		{
			get { return _infoDiverses; }
			set {
				ErrorMsgInfoDiverses = ValidateProperty(value, "InfoDiverses");
				_infoDiverses = value;

				IsInfoError = ErrorMsgInfoDiverses != null;
				OnNotifyPropertyChanged("HasErrors");
			}
		}
		private string _infoDiverses;

		/// <summary>
		/// Propriété pour afficher le message d'erreur.
		/// </summary>
		public string ErrorMsgNomFan
		{
			get { return _erroMsgNomFan; }
			set
			{
				_erroMsgNomFan = value;
				OnNotifyPropertyChanged();
			}
		}
		private string _erroMsgNomFan;

		/// <summary>
		/// Propriété pour afficher le message d'erreur.
		/// </summary>
		public string ErrorMsgInfoDiverses
		{
			get { return _errorMsgInfoDiverses; }
			set
			{
				_errorMsgInfoDiverses = value;
				OnNotifyPropertyChanged();
			}
		}
		private string _errorMsgInfoDiverses;


		public bool HasErrors { get { return IsNameError || IsInfoError; } }
		private bool IsNameError = true;
		private bool IsInfoError = true;


		protected string ValidateProperty(object value, string propertyName)
		{
			var info = this.GetType().GetProperty(propertyName);

			IEnumerable<string> errorInfos =
				  (from va in info.GetCustomAttributes(true).OfType<ValidationAttribute>()
				   where !va.IsValid(value)
				   select va.FormatErrorMessage(string.Empty)).ToList();


			if (errorInfos.Count() > 0)
			{
				return errorInfos.FirstOrDefault<string>();
			}
			return null;
		}

		/// <summary>
		/// Retourne un "Fan"
		/// </summary>
		/// <returns></returns>
		internal Fan ToFan()
		{
			Fan fan = new Fan()
			{
				Nom = this.NomFan,
				InfoDiverses = this.InfoDiverses
			};

			return fan;
		}


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
