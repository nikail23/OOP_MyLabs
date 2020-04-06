using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyShapes
{
    [Serializable]
    public class Triangle : Shape
    {
        protected Color color;
        protected int thickness;
        protected Point[] points;
        [NonSerialized]
        private Point firstTrianglePoint, secondTrianglePoint, thirdTrianglePoint;
        
        public Triangle(Point firstPoint, Point secondPoint, Color color, int thickness, String name) : base(firstPoint, secondPoint, name)
        {
            this.color = color;
            this.thickness = thickness;
        }

        public override void Draw(Graphics graphic)
        {
            Pen pen = new Pen(color, thickness);
            CheckCondition();
            graphic.DrawPolygon(pen, points);
        }

        public void CheckCondition()
        {
            if ((firstPoint.X < secondPoint.X) && (firstPoint.Y < secondPoint.Y))
            {
                firstTrianglePoint.X = Math.Abs((firstPoint.X - secondPoint.X) / 2) + firstPoint.X;
                firstTrianglePoint.Y = firstPoint.Y;
                secondTrianglePoint.X = firstPoint.X;
                secondTrianglePoint.Y = secondPoint.Y;
                thirdTrianglePoint.X = secondPoint.X;
                thirdTrianglePoint.Y = secondPoint.Y;
            }
            else if ((firstPoint.X < secondPoint.X) && (firstPoint.Y > secondPoint.Y))
            {
                firstTrianglePoint.X = Math.Abs((firstPoint.X - secondPoint.X) / 2) + firstPoint.X;
                firstTrianglePoint.Y = secondPoint.Y;
                secondTrianglePoint.X = firstPoint.X;
                secondTrianglePoint.Y = firstPoint.Y;
                thirdTrianglePoint.X = secondPoint.X;
                thirdTrianglePoint.Y = firstPoint.Y;
            }
            else if ((firstPoint.X > secondPoint.X) && (firstPoint.Y < secondPoint.Y))
            {
                firstTrianglePoint.X = firstPoint.X - Math.Abs((firstPoint.X - secondPoint.X) / 2);
                firstTrianglePoint.Y = firstPoint.Y;
                secondTrianglePoint.X = secondPoint.X;
                secondTrianglePoint.Y = secondPoint.Y;
                thirdTrianglePoint.X = firstPoint.X;
                thirdTrianglePoint.Y = secondPoint.Y;
            }
            else
            {
                firstTrianglePoint.X = firstPoint.X - Math.Abs((firstPoint.X - secondPoint.X) / 2);
                firstTrianglePoint.Y = secondPoint.Y;
                secondTrianglePoint.X = secondPoint.X;
                secondTrianglePoint.Y = firstPoint.Y;
                thirdTrianglePoint.X = firstPoint.X;
                thirdTrianglePoint.Y = firstPoint.Y;
            }
            points = new Point[] { firstTrianglePoint, secondTrianglePoint, thirdTrianglePoint };
        }

        public override void ShowShapeParameters(DataGridView parametersGrid)
        {
            parametersGrid.Rows.Clear();
            parametersGrid.Rows.Add("Тип:", name);
            parametersGrid.Rows.Add("X1:", firstPoint.X);
            parametersGrid.Rows.Add("Y1:", firstPoint.Y);
            parametersGrid.Rows.Add("X2:", secondPoint.X);
            parametersGrid.Rows.Add("Y2:", secondPoint.Y);
            parametersGrid.Rows.Add("Цвет:", "");
            parametersGrid[1, 5].Style.BackColor = color;
            parametersGrid.Rows.Add("Толщина:", thickness);
        }

        public override void ConfirmShapeParametersChange(DataGridView parametersGrid)
        {
            name = parametersGrid[PropertyColumnIndex, NameIndex].Value.ToString();
            firstPoint.X = int.Parse(parametersGrid[PropertyColumnIndex, FirstPointXIndex].Value.ToString());
            firstPoint.Y = int.Parse(parametersGrid[PropertyColumnIndex, FirstPointYIndex].Value.ToString());
            secondPoint.X = int.Parse(parametersGrid[PropertyColumnIndex, SecondPointXIndex].Value.ToString());
            secondPoint.Y = int.Parse(parametersGrid[PropertyColumnIndex, SecondPointYIndex].Value.ToString());
            color = parametersGrid[PropertyColumnIndex, ColorIndex].Style.BackColor;
            thickness = int.Parse(parametersGrid[PropertyColumnIndex, ThicknessIndex].Value.ToString());
        }
    }
}
