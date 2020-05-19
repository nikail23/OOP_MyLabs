using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace MyShapes
{
    [Serializable]
    [DataContract]
    public class Rectangle : Shape
    {
        public Rectangle() { }

        public Rectangle(Point firstPoint, Point secondPoint, Color color, int thickness, string name) : base(firstPoint, secondPoint, name, color, thickness) { }

        [DataMember]
        protected virtual int Width
        {
            get
            {
                return Math.Abs(secondPoint.X - firstPoint.X);
            }
            set { }
        }

        [DataMember]
        protected int Height
        {
            get
            {
                return Math.Abs(secondPoint.Y - firstPoint.Y);
            }
            set { }
        }

        [DataMember]
        protected Point TopLeftPoint
        {
            get
            {
                var x = Math.Min(firstPoint.X, secondPoint.X);
                var y = Math.Min(firstPoint.Y, secondPoint.Y);
                return new Point(x, y);
            }
            set { }
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
            parametersGrid[1, 5].Style.BackColor = Color.FromArgb(color);
            parametersGrid.Rows.Add("Толщина:", thickness);
        }

        public override void ConfirmShapeParametersChange(DataGridView parametersGrid)
        {
            name = parametersGrid[PropertyColumnIndex, NameIndex].Value.ToString();
            firstPoint.X = int.Parse(parametersGrid[PropertyColumnIndex, FirstPointXIndex].Value.ToString());
            firstPoint.Y = int.Parse(parametersGrid[PropertyColumnIndex, FirstPointYIndex].Value.ToString());
            secondPoint.X = int.Parse(parametersGrid[PropertyColumnIndex, SecondPointXIndex].Value.ToString());
            secondPoint.Y = int.Parse(parametersGrid[PropertyColumnIndex, SecondPointYIndex].Value.ToString());
            color = parametersGrid[PropertyColumnIndex, ColorIndex].Style.BackColor.ToArgb();
            thickness = int.Parse(parametersGrid[PropertyColumnIndex, ThicknessIndex].Value.ToString());
        }

        public override void Draw(Graphics graphic)
        {
            var pen = new Pen(Color.FromArgb(color), thickness);
            graphic.DrawRectangle(pen, TopLeftPoint.X, TopLeftPoint.Y, Width, Height);
        }
    }
}
