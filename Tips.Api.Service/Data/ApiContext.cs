using Microsoft.EntityFrameworkCore;
using Tips.Data.Mapping;
using Tips.Model;

namespace Tips.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }
 
        public DbSet<Tip> Tips { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            new TipMap(modelBuilder.Entity<Tip>());
        }
    }
}

