using FansApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FansApp.Models
{
	public class FanModelValidation
	{
		[Required(ErrorMessage = "Doit avoir un nom.")]
		[StringLength(10, ErrorMessage = "Le nom est trop long, 10 caractères max")]
		public string Nom { get; set; }

		[Required(ErrorMessage = "Manque l'info.")]
		public string InfoDiverse { get; set; }

		[Required(ErrorMessage = "Choisir une date d'inscription")]
		public DateTime? DateInscription { get; set; }

		internal Fan ToFan()
		{
			return new Fan()
			{
				Nom = this.Nom,
				InfoDiverse = this.InfoDiverse,
				DateInscription = DateInscription.Value
			};
		}
	}
}
