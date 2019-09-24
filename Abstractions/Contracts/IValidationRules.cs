namespace Abstractions.Contracts
{
    public interface IValidationRules
    {
        bool IsValid(string input);
        string toString();
    }
}
