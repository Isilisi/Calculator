namespace Calculator.Core;

public interface IToExpressionParser<in TParsable>
{
    Expression Parse(TParsable parsable);
}