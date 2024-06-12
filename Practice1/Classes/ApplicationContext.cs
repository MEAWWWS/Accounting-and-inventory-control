using Microsoft.EntityFrameworkCore;
namespace Practice1.Classes
{
    public class ApplicationContext1 : DbContext
    {
        public DbSet<Worker> Workers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Practic1.db");
        }
    }
}
