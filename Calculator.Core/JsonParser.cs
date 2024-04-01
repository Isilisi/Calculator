using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Calculator.Core.Operations;

namespace Calculator.Core;

public class JsonParser : IToExpressionParser<JsonNode>
{
    public Expression Parse(JsonNode parsable)
    {
        var maths = parsable["Maths"];
        var expressionDto = maths["Operation"].Deserialize<ExpressionDto>();
        return ParseExpression(expressionDto);
    }

    private Expression ParseExpression(ExpressionDto expressionDto)
    {
        var operationName = expressionDto.ID;
        var operation = Operation.FromName(operationName);
        var subexpressions = expressionDto
            .Value
            .Select(double.Parse)
            .Select(Expression.CreateSingleValued)
            .ToList();
        if (expressionDto.Operation != null)
        {
            var subexpression = ParseExpression(expressionDto.Operation);
            subexpressions.Add(subexpression);
        }

        return Expression.CreateNested(subexpressions, operation);
    }

    private class ExpressionDto
    {
        [JsonPropertyName("@ID")]
        public string ID { get; set; }
        public List<string> Value { get; set; }
        public ExpressionDto? Operation { get; set; }
    }
}