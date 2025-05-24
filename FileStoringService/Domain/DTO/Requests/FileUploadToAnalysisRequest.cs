namespace FileStoringService.Domain.DTO.Requests
{
  public record FileUploadToAnalysisRequest
  {
    public int Hash { get; set; }
    
    public string Content { get; set; }
  }
}
