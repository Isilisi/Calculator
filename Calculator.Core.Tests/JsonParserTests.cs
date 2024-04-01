using System.Text.Json.Nodes;
using FluentAssertions;

namespace Calculator.Core.Tests;

public class JsonParserTests
{
    private readonly JsonParser _sut = new();
    [Test]
    public void Addition()
    {
        // Arrange
        var jsonString = """
                         {
                         "Maths": {
                           "Operation": {
                             "@ID": "Plus",
                             "Value": [
                               "2",
                               "3"
                             ]
                           }
                         }
                         }
                         """;
        var jsonDocument = JsonNode.Parse(jsonString);
        var expectedResult = 5;

        // Act
        var expression = _sut.Parse(jsonDocument);
        var result = expression.Evaluate();

        // Assert
        result.Should().Be(expectedResult);
    }
    
    [Test]
    public void Complex()
    {
        // Arrange
        var jsonString = """
                         {
                           "Maths": {
                             "Operation": {
                               "@ID": "Plus",
                               "Value": [
                                 "2",
                                 "3"
                               ],
                               "Operation": {
                                 "@ID": "Multiplication",
                                 "Value": [
                                   "4",
                                   "5"
                                 ]
                               }
                             }
                           }
                         }
                         """;
        var jsonDocument = JsonNode.Parse(jsonString);
        var expectedResult = 25;

        // Act
        var expression = _sut.Parse(jsonDocument);
        var result = expression.Evaluate();

        // Assert
        result.Should().Be(expectedResult);
    }
}