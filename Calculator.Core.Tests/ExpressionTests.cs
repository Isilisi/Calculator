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
}