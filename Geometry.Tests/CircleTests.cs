namespace MindBox.Geometry.Tests;

public class CircleTests : Shape2DTests
{
    protected override Shape2D CreateShape2D()
    {
        return new Circle(1);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(double.MinValue)]
    [InlineData(double.MaxValue)]
    public void Circle_Ctor_Throws_On_Invalid_Radius(double radius)
    {
        Assert.ThrowsAny<ArgumentException>(() => { var circle = new Circle(radius); });
    }
}
