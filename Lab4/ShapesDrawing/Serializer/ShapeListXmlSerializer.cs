using MyShapes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ShapesDrawing
{
    public class ShapeListXmlSerializer : IShapeListSerializer
    {
        private const string Path = "shapes.xml";

        public IList<Shape> Deserialize(Type[] types)
        {
            var formatter = new XmlSerializer(typeof(List<Shape>), types);

            using (var fileStream = new FileStream(Path, FileMode.Open))
            {
                return (List<Shape>)formatter.Deserialize(fileStream);
            }
        }

        public void Serialize(IList<Shape> shapes, Type[] types)
        {
            var formatter = new XmlSerializer(typeof(List<Shape>), types);

            using (var fileStream = new FileStream(Path, FileMode.Create))
            {
                formatter.Serialize(fileStream, shapes);
            }
        }
    }
}
