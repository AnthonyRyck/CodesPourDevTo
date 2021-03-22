using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace FansMobile.Validation
{
    public abstract class ValidationModel : INotifyPropertyChanged
    {
		/// <summary>
		/// Indicateur qu'il y a une erreur dans une propriété.
		/// </summary>
		public abstract bool HasErrors
		{
			get;
		}

		/// <summary>
		/// Pour valider une propriété.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="propertyName"></param>
		/// <returns></returns>
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
