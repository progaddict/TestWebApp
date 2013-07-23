using System;
using System.Web.Optimization;

namespace TestWebApp
{
  public class BundleConfig
  {
    public static void RegisterBundles(BundleCollection bundles)
    {
      bundles.IgnoreList.Clear();
      AddDefaultIgnorePatterns(bundles.IgnoreList);
      bundles.Add(
        new StyleBundle("~/css/bootstrap")
          .Include("~/content/bootstrap.css")
          .Include("~/content/bootstrap.min.css")
        );
      bundles.Add(
        new ScriptBundle("~/scripts/jquery")
          .Include("~/scripts/jquery-{version}.js")
          .Include("~/scripts/jquery-{version}.min.js")
        );
      bundles.Add(
        new ScriptBundle("~/scripts/bootstrap")
          .Include("~/scripts/bootstrap.js")
          .Include("~/scripts/bootstrap.min.js")
        );
      bundles.Add(
        new ScriptBundle("~/scripts/fileupload")
          .Include("~/scripts/fileupload/jquery.ui.widget.js")
          .Include("~/scripts/fileupload/jquery.iframe-transport.js")
          .Include("~/scripts/fileupload/jquery.fileupload.js")
        );
      bundles.Add(
        new ScriptBundle("~/scripts/custom")
          .Include("~/scripts/custom.js")
        );
    }

    public static void AddDefaultIgnorePatterns(IgnoreList ignoreList)
    {
      if (ignoreList == null)
        throw new ArgumentNullException("ignoreList");
      ignoreList.Ignore("*.intellisense.js");
      ignoreList.Ignore("*-vsdoc.js");
      ignoreList.Ignore("*.debug.js", OptimizationMode.WhenEnabled);
      ignoreList.Ignore("*.min.js", OptimizationMode.WhenDisabled);
      ignoreList.Ignore("*.min.css", OptimizationMode.WhenDisabled);
    }
  }
}