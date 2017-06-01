using System.Data.Entity;

namespace WebStatistic.Models
{
    public class StatContext : DbContext
    {
        public DbSet<Statistika> Stats { get; set; }
    }
}