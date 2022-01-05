public class Engine
{
	/// <summary>Liste des produits rejetés</summary>
	public List<Produit> RejetProduits { get; private set; }

	/// <summary>Liste des packs remplis</summary>
	public List<Pack> PacksRemplis { get; private set; }

	/// <summary>Pack en cours de remplissage</summary>
	public Pack PackEnCours { get; private set; }
	
	/// <summary>Compteur de Pack</summary>
	public int CompteurDuJour {get; private set; }

	/// <summary>Données d'acceptation</summary>
	private ConfigProduit _config;

	/// <summary>Poids minimal acceptable par rapport à la marge</summary>
	public double MargePoidsMin;

	/// <summary>Poids maximal acceptable par rapport à la marge</summary>
	public double MargePoidsMax;

	public Engine(ConfigProduit config, int compteurDepart)
	{
		RejetProduits = new List<Produit>();
		PacksRemplis = new List<Pack>();
		_config = config;
		CompteurDuJour = compteurDepart;

		double marge = config.PoidsIdeal * (config.MargeErreurPoids / 100);
		MargePoidsMin = config.PoidsIdeal - marge;
		MargePoidsMax = config.PoidsIdeal + marge;
	}

	#region Public methods

	/// <summary>
	/// Va traiter une liste de produit pour les "packager"
	/// </summary>
	/// <param name="nouveauProduits"></param>
	public void Process(IEnumerable<Produit> nouveauProduits)
	{
		foreach (var produit in nouveauProduits)
		{
			if(Validate(produit))
			{
				AddToPack(produit);
			}
			else
			{
				RejetProduits.Add(produit);
			}	
		}
	}

	#endregion

	#region Private methods

	/// <summary>
	/// Permet d'ajouter un produit dans un pack
	/// </summary>
	/// <param name="produit">Produit acceptable</param>
	private void AddToPack(Produit produit)
	{
		if(PackEnCours == null)
		{
			PackEnCours = new Pack(CompteurDuJour++);	
		}

		PackEnCours.AddProduit(produit);
		if(PackEnCours.Produits.Count == 6)
		{
			PacksRemplis.Add(PackEnCours);
			// Remise à zéro
			PackEnCours = null;
		}
	}

	/// <summary>
	/// Permet de valider ou non un produit
	/// </summary>
	/// <param name="produit"></param>
	/// <returns></returns>
	private bool Validate(Produit produit)
	{
		if(produit.Taille != _config.TailleIdeale)
			return false;

		if(!ValidatePoids(produit.Poids))
			return false;
		
		return true;
	}

	/// <summary>
	/// Valide que le poids du produit est dans la marge d'erreur
	/// </summary>
	/// <param name="poids">Poids du produit</param>
	/// <returns>TRUE : est acceptable.</returns>
	private bool ValidatePoids(double poids)
	{
		return MargePoidsMin <= poids && poids <= MargePoidsMax;
	}

	#endregion
}