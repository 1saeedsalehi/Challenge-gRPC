using Abstractions.Impl;
using MediatR;

namespace Challenge.Server.Handlers
{
    public class DefaultRequest : RequestMessage, IRequest<ResponseMessage>
    {
    }
}
