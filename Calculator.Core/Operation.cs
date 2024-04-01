namespace Calculator.Core;

public abstract class Operation
{
    public abstract double Apply(List<double> values);
}

public class ConstantOperation : Operation
{
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
    public override double Apply(List<double> values)
    {
        return values.Sum();
    }
}

public class Multiplication : Operation
{
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