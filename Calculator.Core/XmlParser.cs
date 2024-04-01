using System.Xml;
using Calculator.Core.Operations;

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
        else if (expressionToParse.Name == "Operation")
        {
            var operationName = expressionToParse.Attributes["ID"].Value;
            var operation = Operation.FromName(operationName);
            var subexpressions = new List<Expression>();
            foreach (XmlNode subexpressionToParse in expressionToParse.ChildNodes)
            {
                var subexpression = ParseExpression(subexpressionToParse);
                subexpressions.Add(subexpression);
            }

            return Expression.CreateNested(subexpressions, operation);
        }
        else
        {
            throw new ArgumentException("Element not supported");
        }
    }
}