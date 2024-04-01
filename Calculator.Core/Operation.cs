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