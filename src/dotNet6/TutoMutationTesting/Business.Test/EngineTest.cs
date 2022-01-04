using Xunit;
using Business;
using System.Collections.Generic;

namespace Business.Test;

public class EngineTest
{
	[Fact]
	public void ProcessWithOnePackOk()
	{
		#region Arrange
		
		ConfigProduit configTest = new ConfigProduit(100, 5, 20);
		List<Produit> ProduitsTest = new List<Produit>()
		{
			new Produit("produitOk-01", 100, 20),
			new Produit("produitOk-02", 101, 20),
			new Produit("produitOk-03", 102, 20),
			new Produit("produitOk-04", 103, 20),
			new Produit("produitOk-05", 104, 20),
			new Produit("produitOk-06", 105, 20),
		};
			
		#endregion
		
		#region Act
		
		Engine engine = new Engine(configTest);
		engine.Process(ProduitsTest);
		
		#endregion
			
		#region Assert
		
		// doit y avoir 6 produits OK (soit un pack complet), 
		Assert.True(engine.PacksRemplis.Count == 1, "Il y a qu'un pack complet (6 produits)");

		#endregion
	}

	[Fact]
	public void ProcessWithRejets()
	{
		#region Arrange
		
		ConfigProduit configTest = new ConfigProduit(100, 5, 20);
		List<Produit> ProduitsTest = new List<Produit>()
		{
			new Produit("produitNOk-01", 106, 20),
			new Produit("produitNOk-02", 94, 20),
			new Produit("produitNOk-03", 100, 21)
		};
			
		#endregion
		
		#region Act
		
		Engine engine = new Engine(configTest);
		engine.Process(ProduitsTest);
		
		#endregion
			
		#region Assert
		
		// Doit avoir 3 rejets.
		Assert.True(engine.RejetProduits.Count == 3, "Il doit y avoir 3 rejets de produit");

		#endregion
	}
}