using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core
{
    public sealed class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<CpuMetric> CpuMetrics { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
