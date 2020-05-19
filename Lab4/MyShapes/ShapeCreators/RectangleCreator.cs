using System.Drawing;

namespace MyShapes
{
    public class RectangleCreator : ShapeCreator
    {
        public override Shape Create(Point firstPoint, Point secondPoint, Color color, int thickness)
        {
            return new Rectangle(firstPoint, secondPoint, color, thickness, "Rectangle");
        }
    }
}
