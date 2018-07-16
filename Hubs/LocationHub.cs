using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ObaOba.API.Hubs
{
    public class LocationHub : Hub
    {
         public async Task GetUserLocation(string user)
        {
            await Clients.All.SendAsync("ReceiveMessage", user);
        }
    }
}