using System.ComponentModel.DataAnnotations;

namespace TestWebApp.Infrastructure.Backend.EF.Entities
{
  public abstract class BaseEntity
  {
    [Key]
    public int Id { set; get; }
  }
}