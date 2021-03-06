﻿using FansMobile.Validation;
using System.ComponentModel.DataAnnotations;

namespace FansMobile.Models
{
	public class FanWithValidation : ValidationModel
	{
		[Required(AllowEmptyStrings = false, ErrorMessage = "Il faut un nom !")]
		[StringLength(10, MinimumLength = 4, ErrorMessage = "Il faut un nom de Fan avec au moins 4 caractères et max 10.")]
		public string NomFan
		{
			get { return _nomFan; }
			set
			{
				ErrorMsgNomFan = ValidateProperty(value, "NomFan");
				IsNameError = ErrorMsgNomFan != null;
				OnNotifyPropertyChanged("HasErrors");

				_nomFan = value;
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
				IsInfoError = ErrorMsgInfoDiverses != null;
				OnNotifyPropertyChanged("HasErrors");

				_infoDiverses = value;
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

		///<see cref="ValidationModel.HasErrors"/>
		public override bool HasErrors { get { return IsNameError || IsInfoError; } }
		
		private bool IsNameError = true;
		private bool IsInfoError = true;
	}

	/// <summary>
	/// Class d'extension.
	/// </summary>
	public static class FanWithValidationExtension
	{
		public static Fan ToFan(this FanWithValidation model)
		{
			return new Fan()
			{
				Nom = model.NomFan,
				InfoDiverses = model.InfoDiverses
			};
		}
	}
}