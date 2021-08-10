using System;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Demo.dotnet.WSocketSharp.BroadcastServer
{
    public class ChatBehavior : WebSocketBehavior
    {
        protected override void OnOpen()
        {
            Console.WriteLine("OnOpen");

            base.OnOpen();
        }

        protected override void OnClose(CloseEventArgs eventArgs)
        {
            Console.WriteLine($"OnClose {eventArgs.Reason}");

            base.OnClose(eventArgs);
        }

        protected override void OnError(ErrorEventArgs eventArgs)
        {
            Console.WriteLine($"OnError: {eventArgs.Message}");

            base.OnError(eventArgs);
        }

        protected override void OnMessage(MessageEventArgs eventArgs)
        {
            Console.WriteLine($"OnMessage: {eventArgs.Data}");

            this.Sessions.Broadcast($"Received at {DateTime.UtcNow:F}");

            base.OnMessage(eventArgs);
        }
    }
}