namespace WebApiCodeFirst.Models
{
    public class Panier
    {
        [Key]
        public Guid IdPanier { get; set; }

        public int IdItem { get; set; }
        public int Quantite { get; set; }

        [ForeignKey("CommandeIdCmd")]
        public string CommandeIdCmd { get; set; }
    }
}