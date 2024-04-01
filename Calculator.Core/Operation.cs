namespace Calculator.Core;

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
}

public class ConstantOperation : Operation
{
    public override Arity Arity { get; } = Arity.CreateArityN(0);
    private readonly double _value;

    public ConstantOperation(double value)
    {
        _value = value;
    }

    public override double Apply(List<double> values)
    {
        return _value;
    }
}

public class Addition : Operation
{
    public override Arity Arity { get; } = Arity.CreateAny();
    public override double Apply(List<double> values)
    {
        return values.Sum();
    }
}

public class Multiplication : Operation
{
    public override Arity Arity { get; } = Arity.CreateAny();
    public override double Apply(List<double> values)
    {
        double result = 1;
        foreach (var value in values)
        {
            result *= value;
        }

        return result;
    }
}

public class Subtraction : Operation
{
    public override Arity Arity { get; } = Arity.CreateArityN(2);
    public override double Apply(List<double> values)
    {
        return values[0] - values[1];
    }
}