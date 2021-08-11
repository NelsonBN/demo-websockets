using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Demo.dotnet.SignalR.Server.HubConfig
{
    public class ChatHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"Client {this.Context.ConnectionId} connected");

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            if(string.IsNullOrWhiteSpace(exception?.Message))
            {
                Console.WriteLine($"Client {this.Context.ConnectionId} disconnected");
            }
            else
            {
                Console.WriteLine($"Client {this.Context.ConnectionId} disconnected > {exception.Message}");
            }

            return base.OnDisconnectedAsync(exception);
        }

        public async Task ClientMessage(string clientMessage)
        {
            Console.WriteLine($"Client {this.Context.ConnectionId} message: {clientMessage}");

            await this.Clients
                .Client(this.Context.ConnectionId)
                .SendAsync("chat.message", DateTime.UtcNow.ToString("HH:mm.ss"));
        }
    }
}