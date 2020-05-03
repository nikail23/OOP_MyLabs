using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyShapes
{
    [Serializable]
    public class Line : Shape
    {
        public Line() { }
        public Line(Point firstPoint, Point secondPoint, Color color, int thickness, String name) : base(firstPoint, secondPoint, name, color, thickness) { }

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

        public override void Draw(Graphics graphic)
        {
            Pen pen = new Pen(Color.FromArgb(color), thickness);
            graphic.DrawLine(pen, firstPoint, secondPoint);
        }
    }

}
