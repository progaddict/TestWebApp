using System;

namespace TestWebApp.Infrastructure.Backend.EF.Entities
{
  public class Image : BaseEntity
  {
    public string ImageRelativePath { set; get; }
    public string Description { set; get; }
  }
}