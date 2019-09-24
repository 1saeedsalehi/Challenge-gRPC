using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Abstractions.Contracts;
using Abstractions.Impl;
using Challenge.Server.Validation;
using MediatR;

namespace Challenge.Server.Handlers
{
    public class DefaultRequestHandler : IRequestHandler<DefaultRequest, ResponseMessage>
    {
        public static readonly List<IValidationRules> Rules = new List<IValidationRules>
        {
            new HelloValidation(),
            new ByeValidation(),
            new PingValidation(),
            new NoCaseValidation()
        };
        public async Task<ResponseMessage> Handle(DefaultRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);

            return new ResponseMessage
            {
                Response = Rules.FirstOrDefault(x => x.IsValid(request.Request)).toString()
            };
        }
    }
}
