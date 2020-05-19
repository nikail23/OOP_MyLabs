using System.Drawing;

namespace MyShapes
{
    public class LineCreator : ShapeCreator
    {
        public override Shape Create(Point firstPoint, Point secondPoint, Color color, int thickness)
        {
            return new Line(firstPoint, secondPoint, color, thickness, "Line");
        }
    }
}
