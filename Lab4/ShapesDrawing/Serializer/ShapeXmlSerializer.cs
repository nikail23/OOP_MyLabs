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
    public class ShapeXmlSerializer : ISerializer
    {
        private const string Path = "shapes.xml";

        public IList<Shape> Deserialize(Type[] types)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Shape>), types);

            using (FileStream fileStream = new FileStream(Path, FileMode.Open))
            {
                return (List<Shape>)formatter.Deserialize(fileStream);
            }
        }

        public void Serialize(IList<Shape> shapes, Type[] types)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Shape>), types);

            using (FileStream fileStream = new FileStream(Path, FileMode.Create))
            {
                formatter.Serialize(fileStream, shapes);
            }
        }
    }
}
