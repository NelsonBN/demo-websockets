using System;
using WebSocketSharp;

namespace Demo.dotnet.WSocketSharp.Client
{
    public static class Program
    {
        public static void Main(string[] _)
        {
            const string WEBSOCKET_ADDRESS = "ws://localhost:5000";
            const string WEBSOCKET_ADDRESS_PATH = "/chat";


            using(var webSocketClient = new WebSocket(WEBSOCKET_ADDRESS + WEBSOCKET_ADDRESS_PATH))
            {
                webSocketClient.OnOpen += _webSocketClient_OnOpen;
                webSocketClient.OnClose += _webSocketClient_OnClose;
                webSocketClient.OnError += _webSocketClient_OnError;
                webSocketClient.OnMessage += _webSocketClient_OnMessage;

                webSocketClient.Connect();
                webSocketClient.Send("Hello world!!!");

                Console.ReadLine();
            }

            Console.WriteLine("Finished application...");
        }

        private static void _webSocketClient_OnOpen(object sender, EventArgs eventArgs)
        {
            Console.WriteLine($"{nameof(_webSocketClient_OnOpen)}");
        }

        private static void _webSocketClient_OnClose(object sender, CloseEventArgs eventArgs)
        {
            Console.WriteLine($"{nameof(_webSocketClient_OnClose)}: {eventArgs.Reason}");
        }

        private static void _webSocketClient_OnError(object sender, ErrorEventArgs eventArgs)
        {
            Console.WriteLine($"{nameof(_webSocketClient_OnError)}: {eventArgs.Message}");
        }

        private static void _webSocketClient_OnMessage(object sender, MessageEventArgs eventArgs)
        {
            Console.WriteLine($"{nameof(_webSocketClient_OnMessage)}: {eventArgs.Data}");
        }
    }
}