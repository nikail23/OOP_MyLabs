using MyShapes;
using ShapesDrawing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Archivator
{
    public class ShapesXmlArchivedSerializer : IShapeListSerializer
    {
        private const string SavePath = "shapes.zip";

        public IList<Shape> Deserialize(Type[] types)
        {
            var archivator = new Archivator();
            var archiveStream = archivator.Open(SavePath);
            var formatter = new XmlSerializer(typeof(List<Shape>), types);
            return (List<Shape>)formatter.Deserialize(archiveStream);

        }

        public void Serialize(IList<Shape> shapes, Type[] types)
        {
            var formatter = new XmlSerializer(typeof(List<Shape>), types);
            using (var shapesStream = new MemoryStream())
            {
                formatter.Serialize(shapesStream, shapes);
                var archivator = new Archivator();
                archivator.Save(shapesStream.ToArray(), SavePath);
            }
        }
    }
}
