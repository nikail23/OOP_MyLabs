using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace ShapesDrawing
{
    class BinarySerializer : ISerializer
    {
        const String path = "shapes.dat";
        private BinaryFormatter formatter;
        public BinarySerializer()
        {
            formatter = new BinaryFormatter();
        }
        public void Serialize(IList<Shape> shapes)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, shapes);
            }
        }
        public IList<Shape> Deserialize()
        {
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                try
                {
                    IList<Shape> shapes = (List<Shape>)formatter.Deserialize(fileStream);
                    return shapes;
                }
                catch (SerializationException ex)
                {
                    MessageBox.Show("Попытка десериализации пустого потока.");
                    return null;
                }
            }
        }
    }
}
