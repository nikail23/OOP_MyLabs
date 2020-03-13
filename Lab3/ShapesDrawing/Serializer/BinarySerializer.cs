using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShapesDrawing
{
    class BinarySerializer : ISerializer
    {
        private BinaryFormatter formatter;
        public  BinarySerializer()
        {
            formatter = new BinaryFormatter();
        }
        public void Serialize(List<Shape> shapes)
        {
            using (FileStream fileStream = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, shapes);
            }
        }
        public List<Shape> Deserialize()
        {
            using (FileStream fileStream = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
                try
                {
                    List<Shape> shapes = (List<Shape>)formatter.Deserialize(fileStream);
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
