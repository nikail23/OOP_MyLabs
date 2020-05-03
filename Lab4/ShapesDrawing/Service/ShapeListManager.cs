using MyShapes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ShapesDrawing
{
    public class ShapeListManager : IShapesListManager
    {
        private IList<Shape> shapes;
        private IList<Shape> deletedShapes;
        private IShapeListSerializer serializer;
        private Shape editableShape;
        private Type[] pluginTypes;

        public ShapeListManager(IShapeListSerializer serializer, IList<Shape> shapes, IList<Shape> deletedShapes)
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
            if (pluginTypes != null)
                shapes = serializer.Deserialize(pluginTypes);
        }
        public IList<Shape> GetList()
        {
            return shapes;
        }
        public void SaveList()
        {
            if (pluginTypes != null)
                serializer.Serialize(shapes, pluginTypes);
        }
        public void RefreshFormShapesList(ListBox shapesListBox)
        {
            shapesListBox.Items.Clear();
            foreach (var shape in shapes)
            {
                if (shape != null)
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

        public void InitializePluginTypes(Type[] pluginTypes)
        {
            if (pluginTypes != null)
                this.pluginTypes = pluginTypes;
        }
    }
}
