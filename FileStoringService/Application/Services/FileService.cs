using FileStoringService.Application.Interfaces;
using FileStoringService.Domain.DTO.Requests;
using FileStoringService.Domain.DTO.Responses;
using FileStoringService.Domain.Entities;
using FileStoringService.Infrastructure.FileStorage;
using FileStoringService.Infrastructure.Repositories;
using System.Text;

namespace FileStoringService.Application.Services
{
  public class FileService : IFileService
  {
    private readonly StorageRepository _repository;
    private readonly IHashService _hashService;
    private readonly LocalFileStorage _storage;

    public FileService(
        StorageRepository repository,
        IHashService hashService,
        LocalFileStorage storage)
    {
      _repository = repository;
      _hashService = hashService;
      _storage = storage;
    }

    public async Task<FileUploadResponse> UploadAsync(FileUploadRequest request)
    {
      byte[] fileBytes;
      using (var ms = new MemoryStream())
      {
        await request.File.CopyToAsync(ms);
        fileBytes = ms.ToArray();
      }

      var content = Encoding.UTF8.GetString(fileBytes);

      int words = content.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
      int paragraphs = content.Split(new[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries).Length;

      var hash = _hashService.ComputeHash(words, paragraphs);


      var requestAnalysis = new FileUploadToAnalysisRequest
      {
        Hash = hash,
        Content = content
      };
      string filePath = null;
      bool saveToDisk = true;
      var fileId = Guid.NewGuid();

      if (saveToDisk)
      {
        filePath = await _storage.SaveAsync(new MemoryStream(fileBytes), fileId);
      }
      // var respone = тут отправляем requestAnalysis в ручку для прохода по бд и сравнения с нашим хешом и возврата Id
      var metadata = new StorageEntity
      {
        Id = fileId,
        fileName = request.File.FileName,
        localPath = filePath,
        Hash = hash
      };

      await _repository.AddAsync(metadata);

      return new FileUploadResponse { Id = new Guid() };
      
    }

    public async Task<byte[]> DownloadAsync(Guid fileId)
    {
      var metadata = await _repository.GetByIdAsync(fileId);
      return metadata == null
          ? throw new FileNotFoundException()
          : await _storage.ReadAsync(fileId);
    }
  }
}
