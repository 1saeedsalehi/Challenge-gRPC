using Challenge.Server.Handlers;
using Echantion;
using Grpc.Core;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Challenge.Server.Services
{
    public class MessageService : Sender.SenderBase
    {
        private readonly ILogger<MessageService> _logger;
        private readonly IMediator _mediator;
        public MessageService(ILogger<MessageService> logger, IMediator mediator)
        {
            //can use assertion instead of this!
            _mediator = mediator ?? throw new ArgumentException($"The parameter '{nameof(mediator)}' could not be null", nameof(mediator));
            _logger = logger ?? throw new ArgumentException($"The parameter '{nameof(logger)}' could not be null", nameof(logger));
        }

        public override async Task SendAsync(RequestMessage request, IServerStreamWriter<ResponseMessage> responseStream, ServerCallContext context)
        {
            _logger.LogDebug($"message received : {request.Name}");

            var result = await _mediator.Send(new DefaultRequest { Request = request.Name });

            await responseStream.WriteAsync(new ResponseMessage
            {
                Message = result.Response
            }) ;

        }
    }
}
