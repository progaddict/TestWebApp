using TestWebApp.Infrastructure.Backend.EF.Entities;
using System.Data.Entity;

namespace TestWebApp.Infrastructure.Backend.EF
{
  public class DbInitializer : DropCreateDatabaseIfModelChanges<TestWebAppDbContext>
  {
    protected override void Seed(TestWebAppDbContext context)
    {
      base.Seed(context);
      var image = new Image { ImageId = "wave.jpg", Description = "A waive." };
      context.Images.Add(image);
      context.SaveChanges();
    }
  }
}