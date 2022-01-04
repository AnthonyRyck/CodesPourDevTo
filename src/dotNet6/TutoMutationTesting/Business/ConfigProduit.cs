
public class ConfigProduit
{
    /// <summary>
    /// Poids idéale pour un produit, en gramme
    /// </summary>
    public double PoidsIdeal { get; private set; }

    /// <summary>
    /// Marge d'erreure acceptable sur le poids en %
    /// </summary>
    public double MargeErreurPoids { get; private set; }

    /// <summary>Taille idéale en cm</summary>
    public int TailleIdeale { get; private set; }


	public ConfigProduit(double poids, ushort marge, int taille)
	{
		PoidsIdeal = poids;
		MargeErreurPoids = marge;
		TailleIdeale = taille;
	}
}