using FileStoringService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FileStoringService.Infrastructure.Data
{
  public class AppDbContext : DbContext
  {
    public DbSet<StorageEntity> Files { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new StorageEntityConfiguration());
    }
  }
}
