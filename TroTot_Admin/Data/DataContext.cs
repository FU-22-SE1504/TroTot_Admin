using Microsoft.EntityFrameworkCore;
using TroTot_Admin.Model;

namespace TroTot_Admin.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Post> Post { get; set; } 

    }
}
