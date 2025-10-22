using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ChessVGC.BE.Hubs
{
    public class ChessHub : Hub
    {
        public async Task SendMoveSingle(string from, string to)
        {
            await Clients.Others.SendAsync("ReceiveMove", from, to);
        }

        public async Task SendMovesDouble(string from, string to)
        {
            await Clients.Others.SendAsync("ReceiveMove", from, to);
        }

        public async Task JoinGame(string gameId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, gameId);
        }

        public async Task LeaveGame(string gameId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, gameId);
        }
    }
}