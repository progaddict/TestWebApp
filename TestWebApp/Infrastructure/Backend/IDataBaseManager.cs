using TestWebApp.Models;
using System.Collections.Generic;

namespace TestWebApp.Infrastructure.Backend
{
  public interface IDataBaseManager
  {
    IEnumerable<Image> GetAllImages();
  }
}