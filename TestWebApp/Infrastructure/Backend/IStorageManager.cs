﻿using System.Web;

namespace TestWebApp.Infrastructure.Backend
{
  public interface IStorageManager
  {
    string Save(HttpPostedFileBase file);
    string GetRelativeFileUrl(string fileId);
  }
}