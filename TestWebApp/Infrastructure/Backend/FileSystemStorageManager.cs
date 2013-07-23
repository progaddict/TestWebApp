using System;
using System.IO;
using System.Web;

namespace TestWebApp.Infrastructure.Backend
{
  public class FileSystemStorageManager : IStorageManager
  {
    private const string _serverFolder = @"~/Uploads/";
    private readonly IDataBaseManager _dbManager;

    public FileSystemStorageManager(IDataBaseManager dbManager)
    {
      _dbManager = dbManager;
    }

    public string Save(HttpPostedFileBase file)
    {
      var fileName = Path.GetFileName(file.FileName);
      var newFolder = Guid.NewGuid().ToString();
      Directory.CreateDirectory(HttpContext.Current.Server.MapPath(_serverFolder + newFolder));
      var fileId =  newFolder + "/" + fileName;
      var serverFilePath = HttpContext.Current.Server.MapPath(_serverFolder + fileId);
      file.SaveAs(serverFilePath);
      // TODO: save info to db as well
      return fileId;
    }

    public string GetFileUrl(string relativeFilePath)
    {
      var result = "";
      return result;
    }
  }
}