using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ListaTelefonica.CrossCuting.DependencyInjection;
using ListaTelefonica.CrossCuting.Factory;

namespace ListaTelefonica.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);            
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ContainerDI.RegisterElements();
        }

        public override void Dispose()
        {
            base.Dispose();
            ContextFactory.DefaultContext.Dispose();
        }
    }
}
