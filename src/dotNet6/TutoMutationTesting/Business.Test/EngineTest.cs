using Xunit;
using Business;
using System.Collections.Generic;

namespace Business.Test;

public class EngineTest
{
	/// <summary>Configuration des produits pour les tests</summary>
	ConfigProduit configTest = new ConfigProduit(100, 5, 20);

	/// <summary>Liste de produits à tester</summary>
	private List<Produit> ProduitsTest = new List<Produit>()
	{
		new Produit("produitOk-01", 100, 20),
		new Produit("produitOk-02", 101, 20),
		new Produit("produitOk-03", 102, 20),
		new Produit("produitOk-04", 103, 20),
		new Produit("produitOk-05", 104, 20),
		new Produit("produitOk-06", 105, 20),
		new Produit("produitOk-07", 98, 20),

		new Produit("produitNOk-01", 106, 20),
		new Produit("produitNOk-02", 94, 20),
		new Produit("produitNOk-03", 100, 21)
	};

	[Fact]
	public void EngineProcessTest()
	{
		#region Arrange
		
		Engine engine = new Engine(configTest);
			
		#endregion
		
		#region Act
		
		engine.Process(ProduitsTest);
		
		#endregion
			
		#region Assert
		
		// doit y avoir 7 produits OK (soit un pack complet), 
		// et un pack commencé
		// et 3 rejets.
		Assert.True(engine.PacksRemplis.Count == 1, "Il y a qu'un pack complet (6 produits)");
		Assert.True(engine.RejetProduits.Count == 3, "Il doit y avoir 3 rejets de produit");

		#endregion
	}
}