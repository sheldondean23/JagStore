using JagStore.NHibernate;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace JagStore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected SessionHelper _sessionHelper = null;

        protected void Application_Start()
        {
            // start log4net
            XmlConfigurator.Configure();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }       
 
protected void Application_BeginRequest(object sender, EventArgs e)
        {
            _sessionHelper = new SessionHelper();
            _sessionHelper.OpenSession();
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            _sessionHelper = new SessionHelper();
            _sessionHelper.CloseSession();
        }
    }
}
