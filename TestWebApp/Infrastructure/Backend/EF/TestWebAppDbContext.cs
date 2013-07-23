using TestWebApp.Infrastructure.Backend.EF.Entities;
using System.Data.Entity;

namespace TestWebApp.Infrastructure.Backend.EF
{
  public class TestWebAppDbContext : DbContext
  {
    public DbSet<Image> Images { set; get; }
  }
}