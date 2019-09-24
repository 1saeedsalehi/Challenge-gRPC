using System;
using Abstractions.Contracts;

namespace Challenge.Server.Validation
{
    public class PingValidation : IValidationRules
    {
        private static readonly string _name = "Ping";
        public bool IsValid(string input)
        {
            return input.Equals(_name, StringComparison.InvariantCultureIgnoreCase);
        }

        public string toString()
        {
            return "Pong";
        }
    }
}
