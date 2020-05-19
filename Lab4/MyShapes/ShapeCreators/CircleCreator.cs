using System.Drawing;

namespace MyShapes
{
    public class CircleCreator : ShapeCreator
    {
        public override Shape Create(Point firstPoint, Point secondPoint, Color color, int thickness)
        {
            return new Circle(firstPoint, secondPoint, color, thickness, "Circle");
        }
    }
}
