using Abstractions.Contracts;

namespace Abstractions.Impl
{
    public class RequestMessage : IRequestMessage
    {
        public string Request { get; set; }
    }
}
