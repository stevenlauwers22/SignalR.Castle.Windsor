using System.Web;
using System.Web.Routing;
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
            // Register the default hubs route: ~/signalr/hubs
            RouteTable.Routes.MapHubs();            
        }
    }
}
