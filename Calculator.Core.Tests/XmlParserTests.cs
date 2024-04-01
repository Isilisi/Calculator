using System.Xml;
using FluentAssertions;

namespace Calculator.Core.Tests;

public class XmlParserTests
{
    private XmlParser _sut = new XmlParser();
    
    [Test]
    public void SingleValue()
    {
        // Arrange
        var xmlString = """
                        <?xml version="1.0" encoding="UTF-8"?>
                        <Maths>
                        <Value>2</Value>
                        </Maths>
                        """;
        var xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(xmlString);
        var expectedResult = 2;

        // Act
        var expression = _sut.Parse(xmlDocument);
        var result = expression.Evaluate();

        // Assert
        result.Should().Be(expectedResult);
    }
    
    [Test]
    public void Addition()
    {
        // Arrange
        var xmlString = """
                        <?xml version="1.0" encoding="UTF-8"?>
                        <Maths>
                        <Operation ID="Plus">
                        <Value>2</Value>
                        <Value>3</Value>
                        </Operation>
                        </Maths>
                        """;
        var xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(xmlString);
        var expectedResult = 5;

        // Act
        var expression = _sut.Parse(xmlDocument);
        var result = expression.Evaluate();

        // Assert
        result.Should().Be(expectedResult);
    }
}