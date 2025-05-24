namespace FileStoringService.Domain.DTO.Responses
{
  public record FileUploadToAnalysisResponse
  {
    public Guid Id { get; set; }

    public bool isPlag { get; set; }
  }
}
