using Challenge.Client.Contracts;
using Echantion;
using Grpc.Core;
using System;
using System.Threading.Tasks;
using static System.Console;

namespace Challenge.Client.Impl
{
    public class HelloRequest : IClientSample
    {
        private readonly Sender.SenderClient _senderClient;

        public HelloRequest(Sender.SenderClient senderClient)
        {
            if (senderClient == null)
                throw new ArgumentNullException(nameof(senderClient));

            _senderClient = senderClient;
        }
        public async Task<AsyncServerStreamingCall<ResponseMessage>> Show()
        {
            WriteLine($"Sending Hello!");
            return await Task.FromResult(_senderClient.SendAsync(new RequestMessage { Name = "Hello" }));

        }
    }
}
