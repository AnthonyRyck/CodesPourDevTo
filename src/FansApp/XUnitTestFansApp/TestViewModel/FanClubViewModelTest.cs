using FansApp.Data;
using FansApp.ViewModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using XUnitTestFansApp.Code;

namespace XUnitTestFansApp.TestViewModel
{
	public class FanClubViewModelTest
	{
		[Fact]
		public void OpenFanPageTest()
		{
			#region ARRANGE

			int idFan = 12;

			// Mock de la "base de donnée"
			var mockDataBase = new Mock<IAccessDatabase>();
			// Quand appel de cette méthode, retourne une liste vide.
			mockDataBase.Setup(db => db.GetAllFans())
						.Returns(new List<Fan>());

			var mockNavigationManager = new Mock<MockNavigationManager>()
			{
				CallBase = true
			};

			#endregion

			#region ACT

			FanClubViewModel viewModel = new FanClubViewModel(mockDataBase.Object, mockNavigationManager.Object);
			viewModel.OpenFanPage(idFan);

			#endregion

			#region ASSERT

			// Vérification que nous passé dans la méthode NavigateTo
			Assert.True(mockNavigationManager.Object.WasNavigateInvoked);
			Assert.Equal("/fan/" + idFan, mockNavigationManager.Object.GoToUri);

			#endregion
		}

		[Fact]
		public void AddFan_AddNewFanIn_AllFansCollection()
		{
			#region ARRANGE

			string nomNouveauFan = "TestUnitaire";

			Fan nouveauFanTest = new Fan()
								{
									Id = 159,
									Nom = nomNouveauFan,
									DateInscription = new DateTime(2021, 5, 9),
									InfoDiverses = "Info159",
									NombreDeClickRecu = 0
								};

			// Mock de la "base de donnée"
			var mockDataBase = new Mock<IAccessDatabase>();
			// Quand appel de cette méthode, retourne une liste de 3 fans.
			mockDataBase.Setup(db => db.GetAllFans())
						.Returns(GetListFakeFans());

			// Retourne notre nouveau Fan.
			mockDataBase.Setup(db => db.AddFan(It.IsAny<string>()))
						.Returns(nouveauFanTest)
						.Verifiable();

			var mockNavigationManager = new Mock<MockNavigationManager>();

			#endregion

			#region ACT

			FanClubViewModel viewModel = new FanClubViewModel(mockDataBase.Object, mockNavigationManager.Object);
			viewModel.AddFan(nomNouveauFan);

			#endregion

			#region ASSERT

			// Vérifie que le nombre de fan à augmenté
			Assert.Equal(4, viewModel.AllFansCollection.Count);

			// Vérifie que notre collection à bien notre fan avec ce nom.
			Assert.Contains(viewModel.AllFansCollection, fan => fan.Nom == nomNouveauFan);

			// Vérifie que la propriété est remis à false.
			Assert.False(viewModel.CanDisplayNewFan);

			// Vérifie que je suis passé UNE SEULE fois dans la méthode AddFan()
			mockDataBase.Verify(mock => mock.AddFan(It.IsAny<string>()), Times.Once);

			#endregion
		}

		/// <summary>
		/// Crée une liste fictive de Fans.
		/// </summary>
		/// <returns></returns>
		private List<Fan> GetListFakeFans()
		{
			return new List<Fan>()
			{
				new Fan(){ Id = 123, Nom = "Test123", DateInscription = new DateTime(2021, 2,3), InfoDiverses = "Info123", NombreDeClickRecu=123 },
				new Fan(){ Id = 456, Nom = "Test456", DateInscription = new DateTime(2024, 5,6), InfoDiverses = "Info456", NombreDeClickRecu=456 },
				new Fan(){ Id = 789, Nom = "Test789", DateInscription = new DateTime(2028, 7,9), InfoDiverses = "Info789", NombreDeClickRecu=789 }
			};
		}

	}
}
