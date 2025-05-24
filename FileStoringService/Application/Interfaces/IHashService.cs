namespace FileStoringService.Application.Interfaces
{
  public interface IHashService
  {
    int ComputeHash(int words, int paragraphs);
  }
}
