using FansApp.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TitanicML.Model;

namespace FansApp.ViewModel
{
	public class TitanicViewModel : ITitanicViewModel
	{
		public TitanicViewModel()
		{
			PassageModel = new PassagerTitanicModelValidation();
		}



		/// <see cref="ITitanicViewModel.PassageModel"/>
		public PassagerTitanicModelValidation PassageModel { get; set; }

		/// <see cref="ITitanicViewModel.PourcentageSurvie"/>
		public string PourcentageSurvie { get; set; }

		/// <see cref="ITitanicViewModel.OnCancel"/>
		public void OnCancel()
		{
			PassageModel = new PassagerTitanicModelValidation();
		}

		/// <see cref="ITitanicViewModel.OnValidSubmit"/>
		public void OnValidSubmit()
		{
			var sampleData = PassageModel.ToModelInput();
			var predictionResult = ConsumeModel.Predict(sampleData);

			PourcentageSurvie = (predictionResult.Score * 100) + " %";
		}
	}
}
