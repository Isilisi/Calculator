namespace Calculator.Core.Operations;
public class Division : Operation
{
    public override Arity Arity { get; } = Arity.CreateArityN(2);
    public override double Apply(List<double> values)
    {
        return values[0] / values[1];
    }
}