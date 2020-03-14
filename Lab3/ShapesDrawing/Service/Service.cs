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
        public void RefreshFormShapesList(ListView shapesListBox)
        {
            shapesListBox.Clear();
            foreach (Shape shape in shapes)
            {
                var listItem = new ListViewItem();
                listItem.Text = shape.name;
                shapesListBox.Items.Add(listItem);
            }
        }
        public void OpenShapeCharacteristics(DataGridView grid, int number)
        {
            if (number >= 0)
            {
                grid.Rows.Clear();
                editableShape = shapes[number];
                grid.Rows.Add("Тип:", editableShape.name);
                grid.Rows.Add("X1:", editableShape.firstPoint.X);
                grid.Rows.Add("Y1:", editableShape.firstPoint.Y);
                grid.Rows.Add("X2:", editableShape.secondPoint.X);
                grid.Rows.Add("Y2:", editableShape.secondPoint.Y);
                if ((editableShape is Rectangle)||(editableShape is Square)||(editableShape is Circle)||(editableShape is Ellipse))
                {
                    Rectangle rectangle = (Rectangle)editableShape;
                    grid.Rows.Add("Цвет:", rectangle.color);
                    grid.Rows.Add("Толщина:", rectangle.thickness);
                }
                if (editableShape is Line)
                {
                    Line line = (Line)editableShape;
                    grid.Rows.Add("Цвет:", line.color);
                    grid.Rows.Add("Толщина:", line.thickness);
                }
                if (editableShape is Triangle)
                {
                    Triangle triangle = (Triangle)editableShape;
                    grid.Rows.Add("Цвет:", triangle.color);
                    grid.Rows.Add("Толщина:", triangle.thickness);
                }
            }          
        }
        public void EditShape(DataGridView grid)
        {
            editableShape.name = grid[1, 0].Value.ToString();
            editableShape.firstPoint.X = int.Parse(grid[1, 1].Value.ToString());
            editableShape.firstPoint.Y = int.Parse(grid[1, 2].Value.ToString());
            editableShape.secondPoint.X = int.Parse(grid[1, 3].Value.ToString());
            editableShape.secondPoint.Y = int.Parse(grid[1, 4].Value.ToString());
            if ((editableShape is Rectangle) || (editableShape is Square) || (editableShape is Circle) || (editableShape is Ellipse))
            {
                Rectangle rectangle = (Rectangle)editableShape;
                // изменения цвета нету, пока что
                rectangle.thickness = int.Parse(grid[1, 6].Value.ToString());
                editableShape = rectangle;
            }
            if (editableShape is Line)
            {
                Line line = (Line)editableShape;
                // изменения цвета нету, пока что
                line.thickness = int.Parse(grid[1, 6].Value.ToString());
                editableShape = line;
            }
            if (editableShape is Triangle)
            {
                Triangle triangle = (Triangle)editableShape;
                // изменения цвета нету, пока что
                triangle.thickness = int.Parse(grid[1, 6].Value.ToString());
                editableShape = triangle;
            }
        }
    }
}
