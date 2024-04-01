namespace Calculator.Core.Operations;
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