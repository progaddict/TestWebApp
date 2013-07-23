using System.Web;
using System.Web.Mvc;
using TestWebApp.Controllers.Base;
using TestWebApp.Infrastructure.Backend;

namespace TestWebApp.Controllers
{
  public class HomeController : BaseController
  {
    private readonly IStorageManager _storage;

    public HomeController(IStorageManager storage)
    {
      _storage = storage;
    }

    public ActionResult Index()
    {
      return View();
    }

    public ActionResult Upload(HttpPostedFileBase image)
    {
      _storage.Save(image);
      return Json(true);
    }
  }
}
