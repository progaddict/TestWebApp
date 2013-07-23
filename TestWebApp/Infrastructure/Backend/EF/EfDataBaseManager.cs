using TestWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace TestWebApp.Infrastructure.Backend.EF
{
  public class EfDataBaseManager : IDataBaseManager
  {
    public IEnumerable<Image> GetAllImages()
    {
      using (var db = new TestWebAppDbContext())
      {
        var result = db.Images.ToArray().Select(e => e.ToModel());
        return result;
      }
    }
  }
}