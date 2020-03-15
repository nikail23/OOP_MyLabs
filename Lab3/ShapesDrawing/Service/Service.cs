using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
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
                    grid.Rows.Add("Цвет:", "");
                    grid[1, 5].Style.BackColor = rectangle.color;
                    grid.Rows.Add("Толщина:", rectangle.thickness);
                }
                if (editableShape is Line)
                {
                    Line line = (Line)editableShape;
                    grid.Rows.Add("Цвет:", "");
                    grid[1, 5].Style.BackColor = line.color;
                    grid.Rows.Add("Толщина:", line.thickness);
                }
                if (editableShape is Triangle)
                {
                    Triangle triangle = (Triangle)editableShape;
                    grid.Rows.Add("Цвет:", "");
                    grid[1, 5].Style.BackColor = triangle.color;
                    grid.Rows.Add("Толщина:", triangle.thickness);
                }
            }          
        }
        public void EditShape(DataGridView grid)
        {
            const int propertyColumnIndex = 1;
            const int nameIndex = 0;
            const int x1Index = 1;
            const int y1Index = 2;
            const int x2Index = 3;
            const int y2Index = 4;
            const int colorIndex = 5;
            const int thicknessIndex = 6;
            editableShape.name = grid[propertyColumnIndex, nameIndex].Value.ToString();
            editableShape.firstPoint.X = int.Parse(grid[propertyColumnIndex, x1Index].Value.ToString());
            editableShape.firstPoint.Y = int.Parse(grid[propertyColumnIndex, y1Index].Value.ToString());
            editableShape.secondPoint.X = int.Parse(grid[propertyColumnIndex, x2Index].Value.ToString());
            editableShape.secondPoint.Y = int.Parse(grid[propertyColumnIndex, y2Index].Value.ToString());
            if ((editableShape is Rectangle) || (editableShape is Square) || (editableShape is Circle) || (editableShape is Ellipse))
            {
                Rectangle rectangle = (Rectangle)editableShape;
                rectangle.color = grid[propertyColumnIndex, colorIndex].Style.BackColor;
                rectangle.thickness = int.Parse(grid[propertyColumnIndex, thicknessIndex].Value.ToString());
                editableShape = rectangle;
            }
            if (editableShape is Line)
            {
                Line line = (Line)editableShape;
                line.color = grid[propertyColumnIndex, colorIndex].Style.BackColor;
                line.thickness = int.Parse(grid[propertyColumnIndex, thicknessIndex].Value.ToString());
                editableShape = line;
            }
            if (editableShape is Triangle)
            {
                Triangle triangle = (Triangle)editableShape;
                triangle.color = grid[propertyColumnIndex, colorIndex].Style.BackColor;
                triangle.thickness = int.Parse(grid[propertyColumnIndex, thicknessIndex].Value.ToString());
                editableShape = triangle;
            }
        }
    }
}
