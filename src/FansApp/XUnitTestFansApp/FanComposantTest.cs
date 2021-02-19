using Bunit;
using FansApp.Composants;
using FansApp.Data;
using System;
using Xunit;

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
			
			TestContext ctx = new TestContext();
			var renderedComponent = ctx.RenderComponent<FanComponent>(Parameter("EtreFan", fanDeTest),
								EventCallback(nameof(FanComponent.ClickCallback),
									(e) =>
									{
										isClickAddClick = true;
									}));

			#endregion

			#region ACT

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

			TestContext ctx = new TestContext();
			IRenderedComponent<FanComponent> renderedComponent = ctx.RenderComponent<FanComponent>(Parameter("EtreFan", fanDeTest),
								EventCallback(nameof(FanComponent.OnClickToFanPage),
									(e) =>
									{
										isClickOpenPage = true;
									}));

			#endregion

			#region ACT

			var buttonTest = renderedComponent.Find("#openFanPage");
			buttonTest.Click();

			#endregion

			#region ASSERT

			Assert.True(isClickOpenPage);

			#endregion
		}
	}
}
