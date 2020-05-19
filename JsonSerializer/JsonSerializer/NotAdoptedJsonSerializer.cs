using MyShapes;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;

namespace NotAdaptedJsonSerializerNamespace
{
    public class NotAdaptedSoapSerializer : INotAdaptedSerializer
    {
        private IList<Shape> GetEditableCopyOfShapesList(IList<Shape> shapes)
        {
            var result = new List<Shape>();
            foreach (var shape in shapes)
            {
                result.Add(shape);
            }
            return result;
        }

        public IList<Shape> Deserialize(string loadPath)
        {
            var jsonSerializer = new DataContractJsonSerializer(typeof(IList<Shape>));
            using (var fileStream = new FileStream(loadPath, FileMode.Open))
            {
                var shapes = (IList<Shape>)jsonSerializer.ReadObject(fileStream);
                var result = new List<Shape>();
                foreach (var shape in shapes)
                {
                    result.Add(shape);
                }
                return result;
            }
        }

        public void Serialize(string savePath, IList<Shape> shapes)
        {
            var jsonSerializer = new DataContractJsonSerializer(typeof(IList<Shape>));
            using (var fileStream = new FileStream(savePath, FileMode.Create))
            {
                jsonSerializer.WriteObject(fileStream, shapes);
            }
        }
    }
}
