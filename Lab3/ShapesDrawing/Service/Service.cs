using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesDrawing
{ 
    public class Service : IService
    {
        List<Shape> shapes;
        List<Shape> deletedShapes;
        BinarySerializer serializer;
        public Service()
        {
            shapes = new List<Shape>();
            deletedShapes = new List<Shape>();
            serializer = new BinarySerializer();
        }
        public void ClearDeletedShapesList()
        {
            deletedShapes.Clear();
        }
        public void ClearShapesList()
        {
            shapes.Clear();
        }
        public void Undo()
        {
            if (shapes.Count != 0)
            {
                deletedShapes.Add(shapes[shapes.Count - 1]);
                shapes.RemoveAt(shapes.Count - 1);
            }
        }
        public void Redo()
        {
            if (deletedShapes.Count != 0)
            {
                shapes.Add(deletedShapes[deletedShapes.Count - 1]);
                deletedShapes.RemoveAt(deletedShapes.Count - 1);
            }
        }
        public void Add(Shape shape)
        {
            shapes.Add(shape);
        }
        public void LoadList()
        {
            shapes = serializer.Deserialize();
        }
        public List<Shape> GetList()
        {
            return shapes;
        }
        public void SaveList()
        {
            serializer.Serialize(shapes);
        }
    }
}
