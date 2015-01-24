using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace SignalRDemos.Web.Hubs.DrawingBoard
{
    public class DrawingBoard : Hub
    {
        private const int BoardWidth = 300;
        private const int BoardHeight = 300;
        private static string[,] _buffer = new string[BoardWidth, BoardHeight];

        public Task BroadcastPoint(int x, int y)
        {
            if (x < 0) x = 0;
            if (y < 0) y = 0;

            _buffer[x, y] = Clients.Caller.color;
            return Clients.Others.DrawPoint(x, y, Clients.Caller.color);
        }

        public Task BroadcastClear()
        {
            _buffer = new string[BoardWidth, BoardHeight];
            return Clients.Others.Clear();
        }

        public override Task OnConnected()
        {
            return Clients.Caller.Update(_buffer);
        }
    }
}