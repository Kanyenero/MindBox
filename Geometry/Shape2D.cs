namespace MindBox.Geometry;

/// <summary>
/// Представляет базовый класс двумерных замкнутых фигур.
/// </summary>
public abstract class Shape2D : Figure2D
{
    /// <summary>
    /// Позволяет создать двумерную замкнутую фигуру <see cref="Shape2D"/>.
    /// </summary>
    protected Shape2D() 
    {
    }

    /// <summary>
    /// Позволяет вычислить площадь фигуры.
    /// </summary>
    /// <returns>Площадь фигуры.</returns>
    public abstract double Square();
}
