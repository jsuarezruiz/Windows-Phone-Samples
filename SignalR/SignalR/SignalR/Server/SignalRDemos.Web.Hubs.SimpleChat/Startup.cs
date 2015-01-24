
using Microsoft.AspNet.SignalR;
using Owin;

namespace SignalRDemos.Web.Hubs.SimpleChat
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapHubs();
        }
    }
}