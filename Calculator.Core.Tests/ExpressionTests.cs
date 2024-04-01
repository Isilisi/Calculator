using FluentAssertions;

namespace Calculator.Core.Tests;

public class ExpressionTests
{
    [Test]
    public void SingleValuedExpression()
    {
        // Arrange
        double value = 5;

        // Act
        var sut = Expression.CreateSingleValued(value);
        var result = sut.Evaluate();

        // Assert
        result.Should().Be(value);
    }
    
    [Test]
    public void Addition()
    {
        // Arrange
        List<double> values = new() { 4, 5 };
        var expectedResult = 9;

        // Act
        var sut = Expression.CreateMultiValued(values, new Addition());
        var result = sut.Evaluate();

        // Assert
        result.Should().Be(expectedResult);
    }
    
    [Test]
    public void Multiplication()
    {
        // Arrange
        List<double> values = new() { 4, 5 };
        var expectedResult = 20;

        // Act
        var sut = Expression.CreateMultiValued(values, new Multiplication());
        var result = sut.Evaluate();

        // Assert
        result.Should().Be(expectedResult);
    }
}