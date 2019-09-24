using System;
using Abstractions.Contracts;

namespace Challenge.Server.Validation
{
    public class HelloValidation : IValidationRules
    {
        private static readonly string _name = "Hello";
        public bool IsValid(string input)
        {
            return input.Equals(_name, StringComparison.InvariantCultureIgnoreCase);
        }

        public string toString()
        {
            return "Hi";
        }
    }
}
