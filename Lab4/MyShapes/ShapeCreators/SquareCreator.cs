using System.Drawing;

namespace MyShapes
{
    public class SquareCreator : ShapeCreator
    {
        public override Shape Create(Point firstPoint, Point secondPoint, Color color, int thickness)
        {
            return new Square(firstPoint, secondPoint, color, thickness, "Square");
        }
    }
}
