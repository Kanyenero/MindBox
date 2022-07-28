using NUnit.Framework;
using MindBox.Task1.Geometry;

namespace MindBox.Task1.Geometry.Tests
{
    [TestFixture]
    public class CircleTests
    {
        [TestCase(0)]
        [TestCase(-1)]
        public void TestCreate_RadiusLessOrEqualsZero_ThrowsException(double radius)
        {
            Assert.Throws<ArgumentException>(delegate { Circle.Create(radius); });
        }

        [TestCase(10, ExpectedResult = Math.PI * 100)]
        public double TestGetSquare_ReturnedValue_Correct(double radius)
        {
            return Circle.Create(radius).GetSquare();
        }
    }
}
