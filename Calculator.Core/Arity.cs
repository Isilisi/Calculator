namespace Calculator.Core;

public class Arity
{
    public bool IsAny { get; }
    public int Value { get; }

    private Arity(bool isAny, int value)
    {
        IsAny = isAny;
        Value = value;
    }

    public static Arity CreateAny() => new Arity(true, -1);
    public static Arity CreateArityN(int n) => new Arity(false, n);
}