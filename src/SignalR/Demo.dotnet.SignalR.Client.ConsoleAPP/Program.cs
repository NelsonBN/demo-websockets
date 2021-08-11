using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace Demo.dotnet.SignalR.Client.ConsoleAPP
{
    public static class Program
    {
        public static async Task Main(string[] _)
        {
            //Set connection
            var connection = new HubConnectionBuilder()
               .WithUrl("http://localhost:5002/chat")
               .Build();

            connection.Reconnecting += _connection_Reconnecting;
            connection.Reconnected += _connection_Reconnected;
            connection.Closed += _connection_Closed;

            connection.On<string>("chat.message", (message) =>
            {
                Console.WriteLine($"Server response: {message}");
            });

            Console.WriteLine("Connecting...");
            await connection.StartAsync();
            Console.WriteLine("Connection started!");

            Console.Write("Your message > ");
            var clientMessage = Console.ReadLine();

            await connection.InvokeAsync("ClientMessage", clientMessage);


            Console.WriteLine("Press key to continue!");
            Console.ReadKey();
        }

        private static Task _connection_Reconnecting(Exception arg)
        {
            Console.WriteLine($"_connection_Reconnecting > {arg?.Message}");

            return Task.CompletedTask;
        }

        private static Task _connection_Reconnected(string arg)
        {
            Console.WriteLine($"_connection_Reconnected > {arg}");

            return Task.CompletedTask;
        }

        private static Task _connection_Closed(Exception arg)
        {
            Console.WriteLine($"_connection_Closed > {arg?.Message}");

            return Task.CompletedTask;
        }
    }
}