namespace Calculator.Core;

public class Expression
{
    private Operation _operation;
    private List<double> _values;

    public Expression(Operation operation, List<double> values)
    {
        _operation = operation;
        _values = values;
    }
}