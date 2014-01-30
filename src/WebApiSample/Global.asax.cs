namespace WebApiSample
{
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using App_Start;
    using MvcExtensions;
    using MvcExtensions.Windsor;

    public class WebApiApplication : WindsorMvcApplication
    {
        public WebApiApplication()
        {
            Bootstrapper.BootstrapperTasks
                .Include<RegisterModelMetadata>()
                .Include<RegisterControllers>()
                .Include<RegisterModelBinders>();
        }

        protected override void OnStart()
        {
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}