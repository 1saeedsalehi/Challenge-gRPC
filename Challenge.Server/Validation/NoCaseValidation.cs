using System;
using Abstractions.Contracts;

namespace Challenge.Server.Validation
{
    public class NoCaseValidation : IValidationRules
    {
        public bool IsValid(string input)
        {
            return false;
        }

        public string toString()
        {
            throw new InvalidOperationException("not a valid case");
        }
    }
}
