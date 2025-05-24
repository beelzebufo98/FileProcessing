using FileStoringService.Application.Interfaces;
using FileStoringService.Domain.DTO.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace FileStoringService.Api.Controllers
{
  [ApiController]
  [Route("api/files")]
  public class FilesController : ControllerBase
  {
    private readonly IFileService _fileService;

    public FilesController(IFileService fileService)
    {
      _fileService = fileService;
    }

    [HttpPost]
    public async Task<IActionResult> Upload([FromForm] FileUploadRequest request)
    {
      var result = await _fileService.UploadAsync(request);
      return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Download(Guid id)
    {
      var content = await _fileService.DownloadAsync(id);
      return File(content, "text/plain", $"{id}.txt");
    }

    [HttpGet("analysis/{id}")]
    public async Task<IActionResult> DownloadForAnalysis(Guid id)
    {
      var content = await _fileService.DownloadAsync(id);
      var result = Encoding.UTF8.GetString(content);
      return File(result, "text/plain", $"{id}.txt");
    }
  }
}
