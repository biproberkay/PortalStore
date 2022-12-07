global using PortalStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using PortalStore.Domain.Contracts;

namespace PortalStore.Infrastructure
{
    public class PortalStoreDbContext : DbContext
    {
        public PortalStoreDbContext(DbContextOptions<PortalStoreDbContext> options):base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customer { get; set; }

#if true // Track Changes derived Audit

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            foreach (var entry in ChangeTracker.Entries<CreateAudit>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreationDate = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.CreationDate = DateTime.Now;
                        break;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
#endif

#if false // SeedData 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new List<Category> { new Category { } });
            base.OnModelCreating(modelBuilder);
        } 
#endif

    }
}