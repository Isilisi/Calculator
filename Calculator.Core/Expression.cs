using Calculator.Core.Operations;

namespace Calculator.Core;
public class Expression
{
    private readonly Operation _operation;
    private readonly List<Expression> _subexpressions;

    private Expression(List<Expression> subexpressions, Operation operation)
    {
        if (!operation.CanApplyToNumArguments(subexpressions.Count))
            throw new ArgumentException("Operation arity does not match the number of provided values");
        _operation = operation;
        _subexpressions = subexpressions;
    }

    public static Expression CreateSingleValued(double value)
    {
        return new Expression(new(),new ConstantOperation(value));
    }

    public static Expression CreateMultiValued(List<double> values, Operation operation)
    {
        var subexpressions = values.Select(CreateSingleValued).ToList();
        return new Expression(subexpressions, operation);
    }

    public static Expression CreateNested(List<Expression> subexpressions, Operation operation)
    {
        return new Expression(subexpressions, operation);
    }

    public double Evaluate()
    {
        var values = _subexpressions.Select(e => e.Evaluate()).ToList();
        return _operation.Apply(values);
    }
}