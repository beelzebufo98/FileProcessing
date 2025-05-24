using FileStoringService.Application.Interfaces;

namespace FileStoringService.Application.Services
{
  public class HashService : IHashService
  {
    private readonly int _seed;
    public HashService(int seed)
    {
      _seed = seed;
    }
    public int ComputeHash(int words, int paragraphs)
    {
      return ((words + paragraphs) * _seed);
    }
  }
}
