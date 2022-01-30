namespace WebApiCodeFirst.Models
{
    public class Client
    {
        [Key]
        public string Id { get; set; }

        [Required(ErrorMessage = "Un prénom est obligatoire")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Un nom est obligatoire")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Un age est obligatoire")]
        public int Age { get; set; }

        public Adresse Adresse { get; set; }

        public ICollection<Telephone> Telephones { get; set; }

        public ICollection<Commande> Commandes { get; set; }
    }
}