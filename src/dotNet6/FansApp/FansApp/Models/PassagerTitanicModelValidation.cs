using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TitanicML.Model;

namespace FansApp.Models
{
	public class PassagerTitanicModelValidation
	{
		[Required(ErrorMessage = "Choisir entre la 1ere, 2nd ou 3eme Classe.")]
		[Range(1, 3, ErrorMessage = "Choisir une classe entre 1, 2 ou 3")]
		public int Classe { get; set; }

		[Required(ErrorMessage = "Manque le sexe du passagé.")]
		public string Sexe { get; set; }

		[Required(ErrorMessage = "Manque l'age")]
		[Range(1, 85, ErrorMessage = "Choisir un age entre 1 et 85 ans")]
		public int Age { get; set; }


		public PassagerTitanicModelValidation()
		{
			Sexe = null;
		}


		internal ModelInput ToModelInput()
		{
			return new ModelInput()
			{
				Pclass = this.Classe,
				Sex = this.Sexe,
				Age = this.Age,

				// Par défaut.
				SibSp = 0F,
				Parch = 0F,
			};
		}
	}
}
