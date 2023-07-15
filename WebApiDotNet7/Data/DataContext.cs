global using Microsoft.EntityFrameworkCore;

namespace WebApiDotNet7.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-MMPBI3G\\MSSQLSERVER02;Database=DotNet7;user=sa;Password=12345;Trusted_Connection=true;TrustServerCertificate=true;");
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
