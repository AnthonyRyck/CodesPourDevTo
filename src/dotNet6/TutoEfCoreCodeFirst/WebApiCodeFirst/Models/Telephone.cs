namespace WebApiCodeFirst.Models
{
    public class Telephone
    {
        [Key]
        public string Number { get; set; }
        
        public string Type { get; set; }

        [ForeignKey("ClientId")]
        public string ClientId { get; set; }
    }
}