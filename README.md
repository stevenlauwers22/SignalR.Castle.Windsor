#Castle Windsor integration for SignalR

---

### Install it
* From NuGet: `Install-Package SignalR.Castle.Windsor -Pre`
* Or add [this class](https://raw.github.com/stevenlauwers22/SignalR.Castle.Windsor/master/Source/SignalR.Castle.Windsor/WindsorDependencyResolver.cs) to your code

### Register it

    // Configure your container
    var container = new WindsorContainer();
    container.Register(...);
    
    // Replace the default dependency resolver with an instance of the WindsorDependencyResolver
    // Make sure this happens before mapping your Hubs.
    GlobalHost.DependencyResolver = new WindsorDependencyResolver(container);
    RouteTable.Routes.MapHubs(); 
