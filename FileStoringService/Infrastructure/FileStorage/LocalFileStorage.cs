namespace FileStoringService.Infrastructure.FileStorage
{
  public class LocalFileStorage
  {
    private readonly string _storagePath;

    public LocalFileStorage(string storagePath)
    {
      _storagePath = storagePath;
      Directory.CreateDirectory(_storagePath);
    }

    public async Task<string> SaveAsync(Stream fileStream, Guid id)
    {
      var filePath = Path.Combine(_storagePath, $"{id}.txt");
      using (var stream = new FileStream(filePath, FileMode.Create))
      {
        await fileStream.CopyToAsync(stream);
      }
      return filePath;
    }

    public async Task<byte[]> ReadAsync(Guid fileId)
    {
      var filePath = Path.Combine(_storagePath, $"{fileId}.txt");
      return await File.ReadAllBytesAsync(filePath);
    }
  }
}
