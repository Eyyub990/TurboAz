using Microsoft.EntityFrameworkCore;
using TurboAzApp.Models.Entity;

namespace TurboAzApp.Models.DbContexts
{
    public class CarDbContext : DbContext
    {
        public CarDbContext()
            : base()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Database=TurboAz;User Id=sa;Password=query;Encrypt=false", opt =>
            {
                opt.MigrationsHistoryTable("MigrationHistory");
            });

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Car).Assembly);
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
    }
}
