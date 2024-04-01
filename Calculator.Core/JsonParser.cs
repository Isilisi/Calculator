using System.Text.Json.Nodes;

namespace Calculator.Core;

public class JsonParser : IToExpressionParser<JsonNode>
{
    public Expression Parse(JsonNode parsable)
    {
        throw new NotImplementedException();
    }
}