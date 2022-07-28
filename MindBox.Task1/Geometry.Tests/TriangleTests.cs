using NUnit.Framework;

namespace MindBox.Task1.Geometry.Tests
{
    [TestFixture]
    public class TriangleTests
    {
        [TestCase(0, 1, 1)]
        [TestCase(1, 0, 1)]
        [TestCase(1, 1, 0)]
        public void TestCreate_SideEqualsZero_ThrowsException(double firstSideLength, double secondSideLength, double thirdSideLength)
        {
            Assert.Throws<ArgumentException>(delegate { Triangle.Create(firstSideLength, secondSideLength, thirdSideLength); });
        }

        [TestCase(-1, 1, 1)]
        [TestCase(1, -1, 1)]
        [TestCase(1, 1, -1)]
        public void TestCreate_SideLessThanZero_ThrowsException(double firstSideLength, double secondSideLength, double thirdSideLength)
        {
            Assert.Throws<ArgumentException>(delegate { Triangle.Create(firstSideLength, secondSideLength, thirdSideLength); });
        }

        [TestCase(10, 1, 1)]
        [TestCase(1, 10, 1)]
        [TestCase(1, 1, 10)]
        public void TestCreate_ExistenceCondition_ThrowsException(double firstSideLength, double secondSideLength, double thirdSideLength)
        {
            Assert.Throws<ArgumentException>(delegate { Triangle.Create(firstSideLength, secondSideLength, thirdSideLength); });
        }

        [TestCase(3, 4, 5, ExpectedResult = true)]
        [TestCase(4, 5, 6, ExpectedResult = false)]
        public bool TestTriangle_IsRight_HasCorrectValue(double firstSideLength, double secondSideLength, double thirdSideLength)
        {
            return Triangle.Create(firstSideLength, secondSideLength, thirdSideLength).IsRight;
        }

        [TestCase(3, 4, 5, ExpectedResult = 6)]
        public double TestGetSquare_ReturnedValue_Correct(double firstSideLength, double secondSideLength, double thirdSideLength)
        {
            return Triangle.Create(firstSideLength, secondSideLength, thirdSideLength).GetSquare();
        }
    }
}
