namespace MindBox.Geometry;

/// <summary>
/// Представляет тип треугольника по сторонам.
/// </summary>
public enum TriangleSideType
{
    /// <summary>
    /// Равносторонний треугольник.
    /// </summary>
    Equilaterial,

    /// <summary>
    /// Равнобедренный треугольник.
    /// </summary>
    Isosceles,

    /// <summary>
    /// Треугольник, у которого нет равных сторон.
    /// </summary>
    Scalene
}
