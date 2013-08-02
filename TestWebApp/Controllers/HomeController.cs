using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestWebApp.Controllers.Base;
using TestWebApp.Infrastructure.Backend;

namespace TestWebApp.Controllers
{
  public class HomeController : BaseController
  {
    private readonly IStorageManager _storage;
    private readonly IDataBaseManager _dbManager;

    public HomeController(IStorageManager storage, IDataBaseManager dbManager)
    {
      _storage = storage;
      _dbManager = dbManager;
    }

    public ActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Upload(HttpPostedFileBase image, string description)
    {
      var imageId = _storage.Save(image);
      _dbManager.SaveImage(imageId, description);
      var imageRelativeUrl = _storage.GetRelativeFileUrl(imageId);
      var imageUrl = Url.Content(imageRelativeUrl);
      return Json(new { ImageUrl = imageUrl });
    }

    public ActionResult GetAllImages()
    {
      var images = _dbManager.GetAllImages();
      var result = images
        .Select(img => new { ImageUrl = Url.Content(_storage.GetRelativeFileUrl(img.ImageRelativePath)) })
        .ToArray();
      return Json(result);
    }
  }
}
