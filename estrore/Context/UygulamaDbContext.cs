using estrore.Entities;
using Microsoft.EntityFrameworkCore;

namespace estrore.Context
{
    public class UygulamaDbContext : DbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> secenek) : base(secenek)
        {
        }
        public DbSet<ProductEntity> Products { get; set; }
    }
}
