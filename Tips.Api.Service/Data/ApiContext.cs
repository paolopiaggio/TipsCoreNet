using Microsoft.EntityFrameworkCore;
using Tips.Model;

namespace Tips.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }
 
        public DbSet<Tip> Tips { get; set; }
    }
}
