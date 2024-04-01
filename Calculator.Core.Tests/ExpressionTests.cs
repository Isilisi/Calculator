using Calculator.Core.Operations;
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
    
    [Test]
    public void Subtraction()
    {
        // Arrange
        List<double> values = new() { 4, 5 };
        var expectedResult = -1;

        // Act
        var sut = Expression.CreateMultiValued(values, new Subtraction());
        var result = sut.Evaluate();

        // Assert
        result.Should().Be(expectedResult);
    }
    
    [Test]
    public void SubtractionFailsOnThreeArguments()
    {
        // Arrange
        List<double> values = new() { 4, 5, 1 };
        var action = () => Expression.CreateMultiValued(values, new Subtraction());

        // Assert
        action.Should().Throw<ArgumentException>();
    }
    
    [Test]
    public void Division()
    {
        // Arrange
        List<double> values = new() { 4, 5 };
        var expectedResult = 0.8;

        // Act
        var sut = Expression.CreateMultiValued(values, new Division());
        var result = sut.Evaluate();

        // Assert
        result.Should().Be(expectedResult);
    }
    
    [Test]
    public void Nested()
    {
        // Arrange
        var sut = Expression.CreateNested(new List<Expression>()
            {
                Expression.CreateSingleValued(2),
                Expression.CreateSingleValued(3),
                Expression.CreateMultiValued(new List<double> {4, 5}, new Multiplication()),
            },
            new Addition());
        var expectedResult = 25;

        // Act
        var result = sut.Evaluate();

        // Assert
        result.Should().Be(expectedResult);
    }
}