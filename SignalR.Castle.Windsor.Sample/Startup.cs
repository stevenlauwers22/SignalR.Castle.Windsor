using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Messaging;
using Owin;

namespace SignalR.Castle.Windsor.Sample
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Configure the dependency resolver
            var container = new WindsorContainer();
            container
                .Register(
                    Component
                        .For<IMessageBus>()
                        .UsingFactoryMethod(k => new MessageBusDecorator(new MessageBus(GlobalHost.DependencyResolver)))
                        .LifestyleSingleton());

            GlobalHost.DependencyResolver = new WindsorDependencyResolver(container);

            app.MapSignalR();
        }
    }
}