 #SignalR.Castle.Windsor

---

### Instal it
* From NuGet: Install-Package SignalR.Castle.Windsor
* Add [this class](https://raw.github.com/stevenlauwers22/SignalR.Castle.Windsor/master/Source/SignalR.Castle.Windsor/WindsorDependencyResolver.cs) to your code

### Register it

1. Configure your container

var container = new WindsorContainer();
container.Register(...);

2. Replace the default dependency resolver with an instance of the WindsorDependencyResolver

GlobalHost.DependencyResolver = new WindsorDependencyResolver(container);

Make sure this happens before mapping your Hubs.