namespace Calculator.Core.Operations;
public abstract class Operation
{
    public abstract Arity Arity { get; }

    public abstract double Apply(List<double> values);

    public bool CanApplyToNumArguments(int numArguments)
    {
        if (Arity.IsAny)
            return true;
        return Arity.Value == numArguments;
    }

    public static Operation FromName(string operationName)
    {
        return operationName switch
        {
            "Plus" => new Addition(),
            _ => throw new ArgumentException("Operation name not supported"),
        };
    }
}