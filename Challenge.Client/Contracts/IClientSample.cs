using System.Threading.Tasks;
using Echantion;
using Grpc.Core;

namespace Challenge.Client.Contracts
{
    public interface IClientSample
    {
        Task<AsyncServerStreamingCall<ResponseMessage>> Show();
    }
}
