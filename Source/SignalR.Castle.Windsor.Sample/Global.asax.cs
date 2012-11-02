using System;
using System.Web;
using Castle.Windsor;
using Microsoft.AspNet.SignalR;

namespace SignalR.Castle.Windsor.Sample
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalHost.DependencyResolver = new WindsorDependencyResolver(new WindsorContainer());
        }
    }
}