using System.Threading.Tasks;
using Abstractions.Impl;

namespace Abstractions.Contracts
{
    public interface IClient
    {
        Task<ResponseMessage> SendAsync(IRequestMessage requestMessage);

        Task<ResponseMessage> SendAsync<TResponseMessage>(IRequestMessage requestMessage)
            where TResponseMessage : IResponseMessage;
    }
}
