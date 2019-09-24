using System;
using System.Threading.Tasks;
using Challenge.Client.Contracts;
using Echantion;
using Grpc.Core;
using static System.Console;

namespace Challenge.Client.Impl
{
    public class ByeRequest : IClientSample
    {
        private readonly Sender.SenderClient _senderClient;

        public ByeRequest(Sender.SenderClient senderClient)
        {
            if (senderClient == null)
                throw new ArgumentNullException(nameof(senderClient));
            _senderClient = senderClient;
        }
        public async Task<AsyncServerStreamingCall<ResponseMessage>> Show()
        {
            WriteLine($"Sending Bye!");
            return await Task.FromResult(_senderClient.SendAsync(new RequestMessage { Name = "Bye" }));

        }
    }
}
