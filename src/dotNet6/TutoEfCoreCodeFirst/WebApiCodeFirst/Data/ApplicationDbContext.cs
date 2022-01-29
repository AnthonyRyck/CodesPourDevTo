using Microsoft.EntityFrameworkCore;

namespace WebApiCodeFirst.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Telephone> Telephones { get; set; }
        public DbSet<Adresse> Adresses { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Panier> Paniers { get; set; }
        public DbSet<Commande> Commandes { get; set; }
    }
}
