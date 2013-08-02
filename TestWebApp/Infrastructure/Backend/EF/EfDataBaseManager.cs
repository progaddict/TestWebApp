using System.Collections.Generic;
using System.Linq;
using Entities = TestWebApp.Infrastructure.Backend.EF.Entities;
using Models = TestWebApp.Models;

namespace TestWebApp.Infrastructure.Backend.EF
{
  public class EfDataBaseManager : IDataBaseManager
  {
    public IEnumerable<Models.Image> GetAllImages()
    {
      using (var db = new TestWebAppDbContext())
      {
        var result = db.Images.ToArray().Select(e => e.ToModel());
        return result;
      }
    }

    public void SaveImage(string imageId, string description)
    {
      using (var db = new TestWebAppDbContext())
      {
        var image = new Entities.Image { ImageRelativePath = imageId, Description = description };
        db.Images.Add(image);
        db.SaveChanges();
      }
    }
  }
}