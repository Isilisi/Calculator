﻿namespace Calculator.Core;

public class Expression
{
    private Operation _operation;
    private List<double> _values;

    private Expression(Operation operation, List<double> values)
    {
        _operation = operation;
        _values = values;
    }

    public static Expression CreateSingleValued(double value)
    {
        return new Expression(new ConstantOperation(value), new());
    }

    public double Evaluate()
    {
        return _operation.Apply(_values);
    }
}