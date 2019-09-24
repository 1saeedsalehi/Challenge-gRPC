using Abstractions.Contracts;

namespace Abstractions.Impl
{
    public class ResponseMessage : IResponseMessage
    {
        public string Response { get; set; }
    }
}
