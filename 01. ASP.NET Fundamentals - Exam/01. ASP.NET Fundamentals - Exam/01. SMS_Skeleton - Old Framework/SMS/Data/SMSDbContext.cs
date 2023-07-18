namespace SMS.Data
{
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Channels;

    // ReSharper disable once InconsistentNaming
    public class SMSDbContext : DbContext
    {
        public SMSDbContext()
        {
            
        }
        public SMSDbContext(DbContextOptions db)
            :base(db) 
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=SMS;Integrated Security=True;TrustServerCertificate=true;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}