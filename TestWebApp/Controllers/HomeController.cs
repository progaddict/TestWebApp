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

    public ActionResult Upload(HttpPostedFileBase image, string description)
    {
      var imageId = _storage.Save(image);
      _dbManager.SaveImage(imageId, description);
      var imageRelativeUrl = _storage.GetRelativeFileUrl(imageId);
      var imageUrl = Url.Content(imageRelativeUrl);
      return Json(imageUrl);
    }
  }
}
