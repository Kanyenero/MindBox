using Mindbox.Geometry.Tests;

namespace MindBox.Geometry.Tests;

public class TriangleTests : Shape2DTests
{
    protected override Shape2D CreateShape2D()
    {
        return new Triangle(3, 4, 5);
    }

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(double.MinValue, double.MinValue, double.MinValue)]
    [InlineData(double.MaxValue, double.MaxValue, double.MaxValue)]
    [InlineData(3, 4, 100)]
    public void Triangle_Ctor_Throws_On_Invalid_Sides(double s1, double s2, double s3)
    {
        Assert.ThrowsAny<ArgumentException>(() => { var triangle = new Triangle(s1, s2, s3); });
    }

    [Theory]
    [InlineData(3, 4, 5)]
    public void Triangle_IsRight_Returns_True(double s1, double s2, double s3)
    {
        // Arrange
        var triangle = new Triangle(s1, s2, s3);

        // Act
        var actual = triangle.IsRight;

        // Assert
        Assert.True(actual);
    }

    [Theory]
    [InlineData(5, 5, 5)]
    public void Triangle_IsRight_Returns_False(double s1, double s2, double s3)
    {
        // Arrange
        var triangle = new Triangle(s1, s2, s3);

        // Act
        var actual = triangle.IsRight;

        // Assert
        Assert.False(actual);
    }
}
