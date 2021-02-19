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
			InfoDiverses = "Fan de Test",
		};


		[Fact]
		public void TestPourMontrerLesDifferentsOutput()
		{
			#region ARRANGE

			var ctx = InitContextTest();

			#endregion

			#region ACT

			// Création du composant FanPage avec les paramètres si besoin.
			var renderedComponent = ctx.RenderComponent<FanPage>(Parameter(nameof(FanPage.idFan), 12));

			#endregion

			#region ASSERT

			// NOTE: le "#" est TRES IMPORTANT !!!

			// infoDiverses : Fan de Test
			var textContent = renderedComponent.Find("#infoDiverses").TextContent;
			Assert.Equal("Info Diverses : " + fanDeTest.InfoDiverses, textContent);

			// <div id="infoDiverses"><u>infoDiverses</u> : Fan de Test</div>
			var outerHtml = renderedComponent.Find("#infoDiverses").OuterHtml;
			// Ajouter le @ et doubler les "" pour faire l'échappement.
			Assert.Equal(@"<div id=""infoDiverses""><u>Info Diverses</u> : " + fanDeTest.InfoDiverses + "</div>", outerHtml);

			// <u>infoDiverses</u> : Fan de Test
			// Faire attention aux espaces qui sont mis dans les div.
			var innerHtml = renderedComponent.Find("#infoDiverses").InnerHtml;
			Assert.Equal("<u>Info Diverses</u> : " + fanDeTest.InfoDiverses, innerHtml);

			// "  : Fan de Test"
			string textInfoDivers = renderedComponent.Find("#infoDiverses").LastChild.TextContent;
			Assert.Equal(" : " + fanDeTest.InfoDiverses, textInfoDivers);

			#endregion
		}

		[Fact]
		public void TestDateInscription()
		{
			#region ARRANGE

			var ctx = InitContextTest();

			#endregion

			#region ACT

			var renderedComponent = ctx.RenderComponent<FanPage>(Parameter(nameof(FanPage.idFan), 12));

			#endregion
			
			#region ASSERT

			var textDate = renderedComponent.Find("#dateInscrit").TextContent;

			Assert.Equal(fanDeTest.DateInscription.ToString("d"), textDate);

			#endregion
		}

		private TestContext InitContextTest()
		{
			var mock = new Mock<IFanViewModel>();

			mock.Setup(fan => fan.FanSelected)
				.Returns(fanDeTest);

			var ctx = new TestContext();
			// Enregistre notre service avec notre moq
			ctx.Services.AddSingleton<IFanViewModel>(mock.Object);

			return ctx;
		}

	}
}