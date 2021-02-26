using Bunit;
using FansApp.Composants;
using FansApp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Moq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Xunit;
using XUnitTestFansApp.Code;
using static Bunit.ComponentParameterFactory;

namespace XUnitTestFansApp
{
	public class FanComposantTest
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
		public void TestAddClick()
		{
			#region ARRANGE

			bool isClickAddClick = false;
			var etreFan = Parameter("EtreFan", fanDeTest);
			var clickCallBackTest = EventCallback(nameof(FanComponent.ClickCallback), (e) => { isClickAddClick = true; });

			#endregion

			#region ACT

			var ctx = InitContextTest();
			var renderedComponent = ctx.RenderComponent<FanComponent>(etreFan, clickCallBackTest);
			
			var buttonTest = renderedComponent.Find("button");
			buttonTest.Click();

			#endregion

			#region ASSERT

			Assert.True(isClickAddClick);

			#endregion
		}

		[Fact]
		public void TestClickToOpenFanPage()
		{
			#region ARRANGE

			bool isClickOpenPage = false;
			var etreFan = Parameter("EtreFan", fanDeTest);
			var onClickToFanPageTest = EventCallback(nameof(FanComponent.OnClickToFanPage), (e) => { isClickOpenPage = true; });

			#endregion

			#region ACT

			var ctx = InitContextTest();
			IRenderedComponent<FanComponent> renderedComponent = ctx.RenderComponent<FanComponent>(etreFan, onClickToFanPageTest);

			var buttonTest = renderedComponent.Find("#openFanPage");
			buttonTest.Click();

			#endregion

			#region ASSERT

			Assert.True(isClickOpenPage);

			#endregion
		}


		[Fact]
		[UseCulture("fr-FR")]
		public void ValideLocalization_JeSuis_EnFrancais()
		{
			#region ARRANGE

			bool isClickOpenPage = false;
			var etreFan = Parameter("EtreFan", fanDeTest);
			var onClickToFanPageTest = EventCallback(nameof(FanComponent.OnClickToFanPage), (e) => { isClickOpenPage = true; });

			#endregion

			#region ACT

			var ctx = InitContextTest();
			IRenderedComponent<FanComponent> renderedComponent = ctx.RenderComponent<FanComponent>(etreFan, onClickToFanPageTest);

			var divJeSuis = renderedComponent.Find("#iam");

			#endregion

			#region ASSERT

			var inner = divJeSuis.InnerHtml;

			Assert.Equal("Je suis : " + fanDeTest.Nom, inner);
			
			#endregion
		}

		[Fact]
		[UseCulture("en-US")]
		public void ValideLocalization_JeSuis_InEnglish()
		{
			#region ARRANGE

			bool isClickOpenPage = false;
			var etreFan = Parameter("EtreFan", fanDeTest);
			var onClickToFanPageTest = EventCallback(nameof(FanComponent.OnClickToFanPage), (e) => { isClickOpenPage = true; });

			#endregion

			#region ACT

			var ctx = InitContextTest();
			IRenderedComponent<FanComponent> renderedComponent = ctx.RenderComponent<FanComponent>(etreFan, onClickToFanPageTest);

			var divJeSuis = renderedComponent.Find("#iam");

			#endregion

			#region ASSERT

			var inner = divJeSuis.InnerHtml;

			Assert.Equal("I am : " + fanDeTest.Nom, inner);

			#endregion
		}

		/// <summary>
		/// Ajouté avec l'article sur l'ajout Localization
		/// </summary>
		/// <returns></returns>
		private TestContext InitContextTest()
		{
			var ctx = new TestContext();

			// Service pour la localization
			ctx.Services.AddLocalization(options => options.ResourcesPath = "Resources")
						.Configure<RequestLocalizationOptions>(options =>
							{
								// Définition de la liste de langue pris en charge.
								var supportedCultures = new List<CultureInfo>()
													{
														 new CultureInfo("en-US"),
														 new CultureInfo("fr-FR")
													};

								// Langue par défaut
								options.DefaultRequestCulture = new RequestCulture("en-US");

								options.SupportedCultures = supportedCultures;
								options.SupportedUICultures = supportedCultures;
							});

			return ctx;
		}
	}
}