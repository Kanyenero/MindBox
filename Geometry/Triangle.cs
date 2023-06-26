namespace MindBox.Geometry;

/// <summary>
/// Представляет треугольник.
/// </summary>
public class Triangle : Shape2D
{
    private readonly double _maxSide = 1e10; // Значение взято для примера.
    private readonly double _side12;
    private readonly double _side23;
    private readonly double _side31;

    /// <summary>
    /// Позволяет создать треугольник <see cref="Triangle"/> по трем сторонам.
    /// </summary>
    /// <remarks>
    /// <para>Выбрасывает <see cref="ArgumentException"/>, если нарушено условие существования треугольника.</para>
    /// <para>Выбрасывает <see cref="ArgumentOutOfRangeException"/>, если значение одного из аргументов 
    /// <paramref name="s1"/>, <paramref name="s2"/>, <paramref name="s3"/> не является положительным или больше заданного порога.</para>
    /// </remarks>
    /// <param name="s1">Длина 1-й стороны.</param>
    /// <param name="s2">Длина 2-й стороны.</param>
    /// <param name="s3">Длина 3-й стороны.</param>
    /// <exception cref="ArgumentException"></exception>
    public Triangle(double s1, double s2, double s3)
    {
        if (s1 <= .0 || s1 > _maxSide)
        {
            throw new ArgumentOutOfRangeException($"Invalid side provided [{s1}]. The value must be greater than zero and less than {_maxSide}.");
        }
        if (s2 <= .0 || s2 > _maxSide)
        {
            throw new ArgumentOutOfRangeException($"Invalid side provided [{s2}]. The value must be greater than zero and less than {_maxSide}.");
        }
        if (s3 <= .0 || s3 > _maxSide)
        {
            throw new ArgumentOutOfRangeException($"Invalid side provided [{s3}]. The value must be greater than zero and less than {_maxSide}.");
        }
        if (s1 > s2 + s3)
        {
            throw new ArgumentException($"Triangle existence violation [{s1} > {s2} + {s3}].", nameof(s1));
        }
        if (s2 > s1 + s3)
        {
            throw new ArgumentException($"Triangle existence violation [{s2} > {s1} + {s3}].", nameof(s2));
        }
        if (s3 > s1 + s2)
        {
            throw new ArgumentException($"Triangle existence violation [{s3} > {s1} + {s2}].", nameof(s3));
        }

        _side12 = s1;
        _side23 = s2;
        _side31 = s3;

        SideType = defineSideType(s1, s2, s3);

        static TriangleSideType defineSideType(double s1, double s2, double s3)
        {
            var sides = new List<double>() { s1, s2, s3 };
            sides.Sort();

            var ss1 = sides[0];
            var ss2 = sides[1];
            var ss3 = sides[2];

            if (ss1 == ss2 && ss1 == ss3)
            {
                return TriangleSideType.Equilaterial;
            }
            if (ss1 == ss2 || ss2 == ss3 || ss1 == ss3)
            {
                return TriangleSideType.Isoceles;
            }

            return TriangleSideType.Scalene;
        }
    }

    /// <summary>
    /// Позволяет получить тип треугольника по сторонам.
    /// </summary>
    public TriangleSideType SideType { get; }

    /// <summary>
    /// Позволяет установить, является ли треугольник прямоугольным.
    /// </summary>
    public bool IsRight
    {
        get
        {
            if (SideType == TriangleSideType.Scalene || SideType == TriangleSideType.Isoceles)
            {
                var sides = new[] { _side12, _side23, _side31 };
                var hyp = sides.Max();
                var legs = sides.Where(side => side < hyp).ToArray();
                var leg1 = legs[0];
                var leg2 = legs[1];

                return hyp * hyp == leg1 * leg1 + leg2 * leg2;
            }

            return false;
        }
    }

    /// <inheritdoc/>
    public override double Square()
    {
        double semiperimeter = (_side12 + _side23 + _side31) / 2.0;

        return Math.Sqrt(semiperimeter * (semiperimeter - _side12) * (semiperimeter - _side23) * (semiperimeter - _side31));
    }
}
