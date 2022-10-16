using HMZ.Data.Enities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HMZ.Data.Data
{
    public class HMZDbContext : DbContext
    {
        public HMZDbContext(DbContextOptions<HMZDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<ProductCategory>? ProductCategories { get; set; }
    }
}
