namespace MindBox.Task1.Geometry
{
    public class Triangle : FlatFigure
    {
        public double FirstSideLength 
        { 
            get;
            private set; 
        }

        public double SecondSideLength 
        { 
            get; 
            private set; 
        }

        public double ThirdSideLength 
        { 
            get; 
            private set; 
        }

        public IEnumerable<double> SideLengths
        {
            get
            {
                yield return FirstSideLength;
                yield return SecondSideLength;
                yield return ThirdSideLength;
            }
        }

        public bool IsRight 
        { 
            get; 
            private set; 
        }

        /// <summary>
        /// <para>Creates an instance of type <see cref="Triangle" />.</para>
        /// <para>The sides must be greater than 0 and must satisfy the triangle existence condition.</para>
        /// </summary>
        /// <param name="firstSideLength"></param>
        /// <param name="secondSideLength"></param>
        /// <param name="thirdSideLength"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static Triangle Create(double firstSideLength, double secondSideLength, double thirdSideLength)
        {
            ValidateArguments(firstSideLength, secondSideLength, thirdSideLength);

            ValidateExistanceCondition(firstSideLength, secondSideLength, thirdSideLength);
            ValidateExistanceCondition(secondSideLength, firstSideLength, thirdSideLength);
            ValidateExistanceCondition(thirdSideLength, secondSideLength, secondSideLength);

            return new Triangle(firstSideLength, secondSideLength, thirdSideLength);
        }

        private static void ValidateArguments(double firstSideLength, double secondSideLength, double thirdSideLength)
        {
            if (firstSideLength <= 0.0)
                throw new ArgumentException($"Argument '{nameof(firstSideLength)}' cannot be less or equals zero. Value was '{firstSideLength}'.");

            if (secondSideLength <= 0.0)
                throw new ArgumentException($"Argument '{nameof(secondSideLength)}' cannot be less or equals zero. Value was '{secondSideLength}'.");

            if (thirdSideLength <= 0.0)
                throw new ArgumentException($"Argument '{nameof(thirdSideLength)}' cannot be less or equals zero. Value was '{thirdSideLength}'.");
        }

        private static void ValidateExistanceCondition(double firstSideLength, double secondSideLength, double thirdSideLength)
        {
            if (firstSideLength > secondSideLength + thirdSideLength)
                throw new ArgumentException($"Triangle existence condition violated ({firstSideLength} > {secondSideLength} + {thirdSideLength})");
        }

        private Triangle(double firstSideLength, double secondSideLength, double thirdSideLength)
        {
            FirstSideLength = firstSideLength;
            SecondSideLength = secondSideLength;
            ThirdSideLength = thirdSideLength;

            IsRight = CheckIsRight();
        }

        private bool CheckIsRight()
        {
            double biggerSideLength = SideLengths.Max();

            var smallerSideLengths = SideLengths
                .Where(sideLength => sideLength < biggerSideLength)
                .ToArray();

            return biggerSideLength * biggerSideLength == 
                smallerSideLengths[0] * smallerSideLengths[0] + 
                smallerSideLengths[1] * smallerSideLengths[1];
        }

        public override double GetSquare()
        {
            if (IsRight)
            {
                var smallerSideLengths = SideLengths
                    .Where(sideLength => sideLength < SideLengths.Max())
                    .ToArray();

                return smallerSideLengths[0] * smallerSideLengths[1] / 2.0;
            }

            double halfPerimeter = SideLengths.Sum() / 3.0;

            return Math.Sqrt(
                halfPerimeter * 
                (halfPerimeter - FirstSideLength) * 
                (halfPerimeter - SecondSideLength) * 
                (halfPerimeter - ThirdSideLength));
        }
    }
}
