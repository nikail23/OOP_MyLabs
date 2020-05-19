using System.Drawing;

namespace MyShapes
{
    public class EllipseCreator : ShapeCreator
    {
        public override Shape Create(Point firstPoint, Point secondPoint, Color color, int thickness)
        {
            return new Ellipse(firstPoint, secondPoint, color, thickness, "Ellipse");
        }
    }
}
