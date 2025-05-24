using System.ComponentModel.DataAnnotations.Schema;

namespace FileStoringService.Domain.Entities
{
  [Table("files")]
  public record StorageEntity
  {
    public Guid Id { get; set; }

    public int Hash { get; set; }

    public string fileName { get; set; }

    public string localPath { get;set; }
  }
}
