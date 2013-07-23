using TestWebApp.Infrastructure.Backend.EF.Entities;
using System.Data.Entity;

namespace TestWebApp.Infrastructure.Backend.EF
{
  public class DbInitializer : DropCreateDatabaseIfModelChanges<TestWebAppDbContext>
  {
    protected override void Seed(TestWebAppDbContext context)
    {
      base.Seed(context);
      var image = new Image { ImagePath = "/blah/blah/blah.jpg" };
      context.Images.Add(image);
      context.SaveChanges();
    }
  }
}