using System.Web;
using System.Web.Routing;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.AspNet.SignalR;
using SignalR.Castle.Windsor.Sample.App_Start;

[assembly: PreApplicationStartMethod(typeof(RegisterHubs), "Start")]

namespace SignalR.Castle.Windsor.Sample.App_Start
{
    public static class RegisterHubs
    {
        public static void Start()
        {
            // Configure the dependency resolver
            var container = new WindsorContainer();
            container
                .Register(
                    Component
                        .For<IMessageBus>()
                        .UsingFactoryMethod(k => new MessageBusDecorator(new MessageBus(GlobalHost.DependencyResolver)))
                        .LifestyleTransient());

            GlobalHost.DependencyResolver = new WindsorDependencyResolver(container);

            // Register the default hubs route: ~/signalr/hubs
            RouteTable.Routes.MapHubs();            
        }
    }
}
