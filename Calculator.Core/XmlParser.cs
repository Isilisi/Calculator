using System.Xml;

namespace Calculator.Core;

public class XmlParser : IToExpressionParser<XmlDocument>
{
    public Expression Parse(XmlDocument parsable)
    {
        var maths = parsable["Maths"];
        var topLevelExpression = ParseExpression(maths.FirstChild);
        return topLevelExpression;
    }

    private Expression ParseExpression(XmlNode expressionToParse)
    {
        if (expressionToParse.Name == "Value")
        {
            var stringValue = expressionToParse.FirstChild.Value;
            var doubleValue = double.Parse(stringValue);
            return Expression.CreateSingleValued(doubleValue);
        }
        else
        {
            throw new ArgumentException("Element not supported");
        }
    }
}