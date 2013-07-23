using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Http;
using System.Web.Mvc;
using TestWebApp.Infrastructure.Backend;
using TestWebApp.Infrastructure.Backend.EF;

namespace TestWebApp
{
  public static class DiConfig
  {
    public static void SetupDi(HttpConfiguration config)
    {
      var builder = new ContainerBuilder();
      WireUpInfrastructure(builder);
      WireUpControllers(builder);
      var container = builder.Build();
      DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
    }

    private static void WireUpInfrastructure(ContainerBuilder builder)
    {
      builder.RegisterType<EfDataBaseManager>().As<IDataBaseManager>().InstancePerHttpRequest();
      builder.RegisterType<FileSystemStorageManager>().As<IStorageManager>().InstancePerHttpRequest();
    }

    private static void WireUpControllers(ContainerBuilder builder)
    {
      builder.RegisterControllers(typeof(MvcApplication).Assembly);
    }
  }
}