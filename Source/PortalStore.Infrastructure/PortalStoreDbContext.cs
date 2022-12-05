global using PortalStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace PortalStore.Infrastructure
{
    public class PortalStoreDbContext : DbContext
    {
        public PortalStoreDbContext(DbContextOptions<PortalStoreDbContext> options):base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

#if false // SeedData 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new List<Category> { new Category { } });
            base.OnModelCreating(modelBuilder);
        } 
#endif

    }
}