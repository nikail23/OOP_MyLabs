using System.Drawing;

namespace MyShapes
{
    public abstract class ShapeCreator
    {
        public abstract Shape Create(Point firstPoint, Point secondPoint, Color color, int thickness);
    }
}
