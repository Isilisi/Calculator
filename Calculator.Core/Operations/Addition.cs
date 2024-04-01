namespace Calculator.Core.Operations;

public class Addition : Operation
{
    public override Arity Arity { get; } = Arity.CreateAny();
    public override double Apply(List<double> values)
    {
        return values.Sum();
    }
}