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
    
    [Test]
    public void Complex()
    {
        // Arrange
        var xmlString = """
                        <?xml version="1.0" encoding="UTF-8"?>
                        <Maths>
                            <Operation ID="Plus">
                                <Value>0.1</Value>
                                <Operation ID="Multiplication">
                                    <Value>2</Value>
                                    <Operation ID="Division">
                                        <Value>1000</Value>
                                        <Value>200</Value>
                                    </Operation>
                                </Operation>
                                <Value>0.01</Value>
                                <Operation ID="Subtraction">
                                    <Value>3</Value>
                                    <Value>2</Value>
                                </Operation>
                            </Operation>
                        </Maths>
                        """;
        var xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(xmlString);
        var expectedResult = 11.11;

        // Act
        var expression = _sut.Parse(xmlDocument);
        var result = expression.Evaluate();

        // Assert
        result.Should().Be(expectedResult);
    }
}