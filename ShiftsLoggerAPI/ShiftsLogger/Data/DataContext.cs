using Microsoft.EntityFrameworkCore;
using ShiftsLogger.Models;

namespace ShiftsLogger.Data
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDB)\ShiftsDb;Initial Catalog=ShiftsDb;Integrated Security=true;TrustServerCertificate=True");
        }

        public DbSet<Shift> Shifts { get; set; }
    }
}