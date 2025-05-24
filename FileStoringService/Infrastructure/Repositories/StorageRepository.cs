using FileStoringService.Domain.Entities;
using FileStoringService.Infrastructure.Data;

namespace FileStoringService.Infrastructure.Repositories
{
  public class StorageRepository
  {
    private readonly AppDbContext _context;

    public StorageRepository(AppDbContext context)
    {
      _context = context;
    }

    public async Task AddAsync(StorageEntity storageEntity)
    {
      await _context.Files.AddAsync(storageEntity);
      await _context.SaveChangesAsync();
    }

    public async Task<StorageEntity> GetByIdAsync(Guid id)
    {
      return await _context.Files.FindAsync(id);
    }
  }
}
