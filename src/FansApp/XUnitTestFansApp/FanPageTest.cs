using Bunit;
using FansApp.Composants;
using FansApp.ViewModel;
using FansApp.Data;
using Moq;
using System;
using Xunit;
using Microsoft.Extensions.DependencyInjection;

using static Bunit.ComponentParameterFactory;

namespace XUnitTestFansApp
{
	public class FanPageTest
	{
		private Fan fanDeTest = new Fan()
		{
			Id = 12,
			Nom = "FanTest",
			DateInscription = new DateTime(2021, 1, 1),
			NombreDeClickRecu = 150,
			InfoDiverse = "Fan de Test",
		};


		[Fact]
		public void TestPourMontrerLesDifferentsOutput()
		{
			#region ARRANGE

			//var mock = new Mock<IFanViewModel>();

			//mock.Setup(library => library.LoadFan(12));
			//mock.Setup(fan => fan.FanSelected)
			//	.Returns(fanDeTest);

			//var ctx = new TestContext();
			//// Enregistre notre service avec notre moq
			//ctx.Services.AddSingleton<IFanViewModel>(mock.Object);

			var ctx = InitComposant();

			#endregion
			
			#region ACT

			// Création du composant FanPage avec les paramètres si besoin.
			var renderedComponent = ctx.RenderComponent<FanPage>(Parameter(nameof(FanPage.idFan), 12));

			#endregion

			#region ASSERT

			// NOTE: le "#" est TRES IMPORTANT !!!

			// InfoDiverse : Fan de Test
			var textContent = renderedComponent.Find("#infoDiverse").TextContent;

			// <div id="infoDiverse"><u>InfoDiverse</u> : Fan de Test</div>
			var outerHtml = renderedComponent.Find("#infoDiverse").OuterHtml;

			// <u>InfoDiverse</u> : Fan de Test
			var innerHtml = renderedComponent.Find("#infoDiverse").InnerHtml;

			// "  : Fan de Test"
			string textInfoDivers = renderedComponent.Find("#infoDiverse").LastChild.TextContent;


			Assert.Equal("Info Divers : " + fanDeTest.InfoDiverse, textContent);

			// Ajouter le @ et doubler les "" pour faire l'échappement.
			Assert.Equal(@"<div id=""infoDiverse""><u>Info Divers</u> : " + fanDeTest.InfoDiverse + "</div>", outerHtml);
			
			// Faire attention aux espaces qui sont mis dans les div.
			Assert.Equal("<u>Info Divers</u> : " + fanDeTest.InfoDiverse, innerHtml);
			Assert.Equal(" : " + fanDeTest.InfoDiverse, textInfoDivers);

			#endregion
		}

		[Fact]
		public void TestDateInscription()
		{
			#region ARRANGE

			var ctx = InitComposant();

			#endregion

			#region ACT

			var renderedComponent = ctx.RenderComponent<FanPage>(Parameter(nameof(FanPage.idFan), 12));

			#endregion
			
			#region ASSERT

			var textDate = renderedComponent.Find("#dateInscrit").TextContent;

			Assert.Equal(fanDeTest.DateInscription.ToString("d"), textDate);

			#endregion
		}

		private TestContext InitComposant()
		{
			var mock = new Mock<IFanViewModel>();

			mock.Setup(fan => fan.LoadFan(12));
			mock.Setup(fan => fan.FanSelected)
				.Returns(fanDeTest);

			var ctx = new TestContext();
			// Enregistre notre service avec notre moq
			ctx.Services.AddSingleton<IFanViewModel>(mock.Object);

			return ctx;
		}

	}
}