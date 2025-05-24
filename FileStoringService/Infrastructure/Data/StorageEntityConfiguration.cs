using FileStoringService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FileStoringService.Infrastructure.Data
{
  public class StorageEntityConfiguration : IEntityTypeConfiguration<StorageEntity>
  {
    public void Configure(EntityTypeBuilder<StorageEntity> builder)
    {
      builder.HasKey(f => f.Id);
      builder.Property(f => f.Hash).IsRequired().HasMaxLength(64);
      builder.Property(f => f.fileName).IsRequired().HasMaxLength(255);
      builder.Property(f => f.localPath).IsRequired();
    }
  }
}
