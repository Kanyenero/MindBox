namespace MindBox.Task1.Geometry
{
    public class Circle : FlatFigure
    {
        public double Radius 
        { 
            get; 
            private set; 
        }

        public static Circle Create(double radius)
        {
            ValidateArguments(radius);

            return new Circle(radius);
        }

        private static void ValidateArguments(double radius)
        {
            if (radius <= 0.0)
                throw new ArgumentException($"Argument '{nameof(radius)}' cannot be less or equals zero. Value was '{radius}'.");
        }

        private Circle(double radius)
        {
            Radius = radius;
        }

        public override double GetSquare()
        {
            return Math.PI * Radius * Radius;
        }
    }
}
