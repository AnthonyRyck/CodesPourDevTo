namespace Business;

public class Produit
{
    public string IdentifiantProduit { get; private set; }
    
    public double Poids { get; private set; }
    
    public int Taille { get; private set; }

    /// <summary>
    /// Constructeur d'un produit.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="poids"></param>
    /// <param name="taille"></param>
    public Produit(string id, double poids, int taille)
    {
        IdentifiantProduit = id;
        Poids = poids;
        Taille = taille;
    }
}


public class Pack
{
    /// <summary>Numéro lot </summary>
    public int NumLot { get; private set; }
    
    /// <summary>Produits contenus dans ce pack</summary>
    public List<Produit> Produits { get; private set; } = new List<Produit>();
    
    /// <summary>
    /// Constructeur d'un pack
    /// </summary>
    /// <param name="numeroLot"></param>
    public Pack(int numeroLot)
    {
        NumLot = numeroLot;
    }

    /// <summary>
    /// Ajoute un produit dans le Pack.
    /// </summary>
    /// <param name="produit"></param>
    public void AddProduit(Produit produit)
    {
        Produits.Add(produit);
    }
}