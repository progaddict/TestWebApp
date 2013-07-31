using System;
using System.IO;
using System.Web;

namespace TestWebApp.Infrastructure.Backend
{
  public class FileSystemStorageManager : IStorageManager
  {
    private const string _serverFolder = @"~/Uploads/";

    public string Save(HttpPostedFileBase file)
    {
      var fileName = Path.GetFileName(file.FileName);
      var newFolder = Guid.NewGuid().ToString();
      Directory.CreateDirectory(HttpContext.Current.Server.MapPath(_serverFolder + newFolder));
      var fileId =  newFolder + "/" + fileName;
      var serverFilePath = HttpContext.Current.Server.MapPath(_serverFolder + fileId);
      file.SaveAs(serverFilePath);
      return fileId;
    }

    public string GetRelativeFileUrl(string fileId)
    {
      var result = _serverFolder + fileId;
      return result;
    }
  }
}