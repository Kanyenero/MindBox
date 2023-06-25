using MindBox.Geometry;

namespace Mindbox.Geometry.Tests;

public abstract class Shape2DTests
{
    protected abstract Shape2D CreateShape2D();

    [Fact]
    public void Square_Returns_Positive_Value()
    {
        // Arrange
        Shape2D shape = CreateShape2D();

        // Act
        var actual = shape.Square();

        // Assert
        Assert.True(actual > 0);
    }
}
