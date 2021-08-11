using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.WSocket.Client
{
    public static class Program
    {
        public static async Task Main(string[] _)
        {
            const string WEBSOCKET_ADDRESS = "ws://localhost:5001/chat";
            var timeout = TimeSpan.FromSeconds(300);

            using(var client = new ClientWebSocket())
            {
                var serviceUri = new Uri(WEBSOCKET_ADDRESS);
                var cancellationTokenSource = new CancellationTokenSource();
                cancellationTokenSource.CancelAfter(timeout);

                try
                {
                    await client.ConnectAsync(serviceUri, cancellationTokenSource.Token);
                    while(client.State == WebSocketState.Open)
                    {

                        Console.Write("Your message > ");
                        var clientMessage = Console.ReadLine();

                        if(!string.IsNullOrWhiteSpace(clientMessage))
                        {
                            var byteMessage = new ArraySegment<byte>(Encoding.UTF8.GetBytes(clientMessage));
                            await client.SendAsync(byteMessage, WebSocketMessageType.Text, true, cancellationTokenSource.Token);

                            var buffer = new byte[1024 * 4];
                            var offset = 0;
                            var packet = 1024;
                            while(true)
                            {
                                var byeToRecieve = new ArraySegment<byte>(buffer, offset, packet);

                                var response = await client
                                    .ReceiveAsync(byeToRecieve, cancellationTokenSource.Token);

                                var responseMessage = Encoding.UTF8.GetString(buffer, offset, response.Count);
                                Console.WriteLine($"\tServer response: {responseMessage}");

                                if(response.EndOfMessage)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
                catch(WebSocketException exception)
                {
                    Console.WriteLine($"ERROR: {exception.Message}");
                }
            }
        }
    }
}