namespace Calculator.Core.Operations;
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