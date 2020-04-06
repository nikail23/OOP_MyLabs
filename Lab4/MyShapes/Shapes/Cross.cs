using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyShapes
{
    [Serializable]
    public class Cross : Shape
    {
        protected Color color;
        protected int thickness;

        public Cross(Point firstPoint, Point secondPoint, Color color, int thickness, String name) : base(firstPoint, secondPoint, name)
        {
            this.thickness = thickness;
            this.color = color;
        }

        public override void Draw(Graphics graphic)
        {
            Pen pen = new Pen(color, thickness);
            graphic.DrawLine(pen, firstPoint, secondPoint);
            int delta = Math.Abs(firstPoint.Y - secondPoint.Y);
            if (firstPoint.Y > secondPoint.Y)
            {
                graphic.DrawLine(pen, new Point(firstPoint.X, firstPoint.X - delta), new Point(secondPoint.X, secondPoint.Y + delta));
            }
            else
            {
                graphic.DrawLine(pen, new Point(firstPoint.X, firstPoint.Y + delta), new Point(secondPoint.X, secondPoint.Y - delta));
            }
        }

        public override void ConfirmShapeParametersChange(DataGridView parametersGrid)
        {
            
        }

        public override void ShowShapeParameters(DataGridView parametersGrid)
        {
            
        }
    }
}
