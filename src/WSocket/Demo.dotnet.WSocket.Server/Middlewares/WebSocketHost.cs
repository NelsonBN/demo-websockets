using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.WSocket.Server.Middlewares
{
    public class WebSocketHost
    {
        public async Task Send(WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            WebSocketReceiveResult result = await webSocket
                .ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

            if(result != null)
            {
                while(!result.CloseStatus.HasValue)
                {
                    string clientMessage = Encoding.UTF8.GetString(new ArraySegment<byte>(buffer, 0, result.Count));
                    Console.WriteLine($"Client message: {clientMessage}");

                    await webSocket.SendAsync(
                        new ArraySegment<byte>(
                        Encoding.UTF8.GetBytes($"Received at {DateTime.UtcNow.ToString("HH:mm.ss")}")),
                        result.MessageType,
                        result.EndOfMessage, CancellationToken.None
                    );

                    result = await webSocket
                        .ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                }
            }

            await webSocket.CloseAsync(
                result.CloseStatus.Value,
                result.CloseStatusDescription,
                CancellationToken.None
            );
        }
    }
}