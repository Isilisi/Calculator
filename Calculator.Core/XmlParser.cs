using System.Xml;

namespace Calculator.Core;

public class XmlParser : IToExpressionParser<XmlDocument>
{
    public Expression Parse(XmlDocument parsable)
    {
        throw new NotImplementedException();
    }
}