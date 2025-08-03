using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using SupportEngineerTest.Web.Models;
using SupportEngineerTest.Web.Services;
using System.Data.Entity;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SupportEngineerTest.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

			var builder = new ContainerBuilder();

			builder.RegisterControllers(typeof(MvcApplication).Assembly);
			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

			builder.RegisterType<ApplicationDbContext>();

			builder.RegisterInstance(new TicketService())
				.As<ITicketService>();
            builder.RegisterType<ApplicationDbContext>();
			var container = builder.Build();

			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

			var config = GlobalConfiguration.Configuration;
			config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

			Database.SetInitializer(new DatabaseInitializer());
	
		}
    }
}
