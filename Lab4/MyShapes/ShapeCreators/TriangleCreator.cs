using System.Drawing;

namespace MyShapes
{
    public class TriangleCreator : ShapeCreator
    {
        public override Shape Create(Point firstPoint, Point secondPoint, Color color, int thickness)
        {
            return new Triangle(firstPoint, secondPoint, color, thickness, "Triangle");
        }
    }
}
