using TestWebApp.Infrastructure.Backend.EF.Entities;
using ViewModels = TestWebApp.Models;

namespace TestWebApp.Infrastructure.Backend.EF
{
  public static class ConverterUtil
  {
    public static ViewModels.Image ToModel(this Image entity)
    {
      var model = new ViewModels.Image { ImagePath = entity.ImagePath };
      return model;
    }
  }
}