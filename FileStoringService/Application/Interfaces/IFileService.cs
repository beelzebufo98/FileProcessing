using FileStoringService.Domain.DTO.Requests;
using FileStoringService.Domain.DTO.Responses;

namespace FileStoringService.Application.Interfaces
{
  public interface IFileService
  {
    Task<FileUploadResponse> UploadAsync(FileUploadRequest request);
    Task<byte[]> DownloadAsync(Guid fileId);
  }
}
