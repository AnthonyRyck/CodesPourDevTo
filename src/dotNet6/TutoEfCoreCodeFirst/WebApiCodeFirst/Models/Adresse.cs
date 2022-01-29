namespace WebApiCodeFirst.Models
{
    public class Adresse
    {
        [Key]
        public string Id { get; set; }

        public string Numero { get; set; }
        public string Rue { get; set; }
        public string Ville { get; set; }

        [ForeignKey("ClientId")]
        public string ClientId { get; set; }
    }
}