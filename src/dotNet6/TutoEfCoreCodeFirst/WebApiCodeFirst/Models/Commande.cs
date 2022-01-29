namespace WebApiCodeFirst.Models
{
    public class Commande
    {
        [Key]
        public string IdCmd { get; set; }

        [ForeignKey("ClientId")]
        public string ClientId { get; set; }

        public ICollection<Panier> Panier { get; set; }
    }
}