using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Challenge.Client.Contracts;
using Challenge.Client.Impl;
using Echantion;
using Grpc.Core;
using Grpc.Net.Client;

namespace Challenge.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            Sender.SenderClient client = new Sender.SenderClient(channel);

            var demoOperations = new Dictionary<ConsoleKey, IClientSample>
            {
                [ConsoleKey.D1] = new HelloRequest(client),
                [ConsoleKey.D2] = new PingRequest(client),
                [ConsoleKey.D3] = new ByeRequest(client),
                [ConsoleKey.D4] = new BadRequest(client)
            };

            ConsoleKeyInfo consoleKeyInfo;

            do
            {

                ShowConsoleMenu();

                consoleKeyInfo = Console.ReadKey(false);

                if (demoOperations.ContainsKey(consoleKeyInfo.Key))
                {
                    Console.Clear();
                    
                    //exception handling!
                    var replies = await demoOperations[consoleKeyInfo.Key].Show();
                    
                    //this can be refactored to process response asynchronous
                    await foreach (var reply in replies.ResponseStream.ReadAllAsync())
                    {
                        Console.WriteLine(reply.Message);
                    }
                }
                else
                {
                    Console.WriteLine("invalid choice! please try again :)");
                }

            } while (consoleKeyInfo.Key != ConsoleKey.Escape);

            
            Console.WriteLine("Done. Press any key to exit...");

            Console.ReadKey();


        }

        private static void ShowConsoleMenu()
        {
            Console.WriteLine("Press 1 to send Hello");
            Console.WriteLine("Press 2 to send Ping");
            Console.WriteLine("Press 3 to send Bye");
            Console.WriteLine("Press 4 to send a bad request!");

            Console.WriteLine("Press ESC Exit");
        }
    }
}
