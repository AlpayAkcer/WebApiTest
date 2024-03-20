using Microsoft.EntityFrameworkCore;
using WebApiTest.Entities;

namespace WebApiTest.DataAccessLayer
{
    public class HotelDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=TestDb;uid=sa;pwd=4675190;TrustServerCertificate=True;");
        }
        public DbSet<Hotel> Hotels { get; set; }
    }
}
