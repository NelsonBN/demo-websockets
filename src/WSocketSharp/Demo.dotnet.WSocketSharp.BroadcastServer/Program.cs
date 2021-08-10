using System;
using WebSocketSharp.Server;

namespace Demo.dotnet.WSocketSharp.BroadcastServer
{
    public static class Program
    {
        // https://www.youtube.com/watch?v=ThiAQAB5Dp4
        public static void Main(string[] _)
        {
            const string WEBSOCKET_ADDRESS = "ws://localhost:5000";
            const string WEBSOCKET_ADDRESS_PATH = "/chat";

            var webSocketServer = new WebSocketServer(WEBSOCKET_ADDRESS);
            webSocketServer.AddWebSocketService<ChatBehavior>(WEBSOCKET_ADDRESS_PATH);

            webSocketServer.Start();
            Console.WriteLine($"Listening in address: {WEBSOCKET_ADDRESS + WEBSOCKET_ADDRESS_PATH}");

            Console.ReadLine();

            webSocketServer.Stop();
        }
    }
}