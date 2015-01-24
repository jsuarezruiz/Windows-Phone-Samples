using Microsoft.AspNet.SignalR;
using Owin;

namespace SignalRDemos.Web.Hubs.DrawingBoard
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HubConfiguration()
                         {
                             EnableDetailedErrors = true
                         };
            app.MapHubs(config);
        }
    }
}