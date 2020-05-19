using MyShapes;
using System.Collections.Generic;
using System.Drawing;

namespace ShapesDrawing
{
    public class ShapeDictionaryFabrike : IShapesDictionaryFabrike
    {
        public IList<ShapeCreator> creators { get; set; }

        public ShapeDictionaryFabrike()
        {
            creators = new List<ShapeCreator>();
            creators.Add(new CircleCreator());
            creators.Add(new SquareCreator());
            creators.Add(new RectangleCreator());
            creators.Add(new TriangleCreator());
            creators.Add(new EllipseCreator());
            creators.Add(new LineCreator());
        }

        public IDictionary<int, Shape> GetShapesDictionary(Point firstPoint, Point secondPoint, Color color, int thickness)
        {
            var dictionary = new Dictionary<int, Shape>();
            var i = 1;
            foreach (var creator in creators)
            {
                dictionary.Add(i, creator.Create(firstPoint, secondPoint, color, thickness));
                i++;
            }
            return dictionary;
        }
    }
}
