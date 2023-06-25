namespace MindBox.Geometry;

/// <summary>
/// Представляет круг.
/// </summary>
public class Circle : Shape2D
{
    private readonly double _maxRadius = 1e10; // Значение взято для примера.
    private readonly double _radius;

    /// <summary>
    /// Позволяет создать круг <see cref="Circle"/>.
    /// </summary>
    /// <remarks>
    /// Выбрасывает <see cref="ArgumentException"/>, если значение аргумента <paramref name="radius"/> не является положительным или больше заданного порога.
    /// </remarks>
    /// <param name="radius">Радиус круга.</param>
    /// <exception cref="ArgumentException"></exception>
    public Circle(double radius)
    {
        if (radius <= .0 || radius > _maxRadius)
        {
            throw new ArgumentOutOfRangeException($"Invalid radius provided [{radius}]. The value must be greater than zero and less than {_maxRadius}.");
        }

        _radius = radius;
    }

    /// <inheritdoc/>
    public override double Square() => Math.PI * _radius * _radius;
}
