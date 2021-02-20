using FansApp.Data;
using FansApp.ViewModel;
using Microsoft.AspNetCore.Components;
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
		public void GetFans_LoadFansTo_AllFansCollectionProperty()
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


			#endregion
		}



	}
}
