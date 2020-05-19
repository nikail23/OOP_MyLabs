using MyShapes;
using System.Collections.Generic;
using System.Drawing;

namespace ShapesDrawing
{
    internal interface IShapesDictionaryFabrike
    {
        IList<ShapeCreator> creators { get; set; }

        IDictionary<int, Shape> GetShapesDictionary(Point firstPoint, Point secondPoint, Color color, int thickness);
    }
}
