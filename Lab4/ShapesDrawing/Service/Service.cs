using MyShapes;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ShapesDrawing
{
    public class Service : IService
    {
        private IList<Shape> shapes;
        private IList<Shape> deletedShapes;
        private ISerializer serializer;
        private Shape editableShape;
        public Service(ISerializer serializer, IList<Shape> shapes, IList<Shape> deletedShapes)
        {
            this.shapes = shapes;
            this.deletedShapes = deletedShapes;
            this.serializer = serializer;
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
        public IList<Shape> GetList()
        {
            return shapes;
        }
        public void SaveList()
        {
            serializer.Serialize(shapes);
        }
        public void RefreshFormShapesList(ListBox shapesListBox)
        {
            shapesListBox.Items.Clear();
            foreach (Shape shape in shapes)
            {
                shapesListBox.Items.Add(shape.name);
            }
        }
        public void ShowShapeParameters(DataGridView parametersGrid, int shapeIndex)
        {
            editableShape = GetShapeByIndex(shapeIndex);
            editableShape.ShowShapeParameters(parametersGrid);
        }

        public void ConfirmShapeParametersChange(DataGridView parametersGrid)
        {
            editableShape.ConfirmShapeParametersChange(parametersGrid);
        }

        private Shape GetShapeByIndex(int shapeIndex)
        {
            try
            {
                return shapes[shapeIndex];
            }
            catch
            {
                return null;
            }
        }
    }
}
