using MyShapes;
using NotAdaptedJsonSerializerNamespace;
using ShapesDrawing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyJsonSerializer
{
    public class AdaptedJsonSerializer : IShapeListSerializer
    {
        private const string SavePath = "shapes.json";
        private NotAdaptedSoapSerializer serializer;

        public AdaptedJsonSerializer()
        {
            serializer = new NotAdaptedSoapSerializer();
        }

        public IList<Shape> Deserialize(Type[] types)
        {
            return serializer.Deserialize(SavePath);
        }

        public void Serialize(IList<Shape> shapes, Type[] types)
        {
            serializer.Serialize(SavePath, shapes);
        }
    }
}
