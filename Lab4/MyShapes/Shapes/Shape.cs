using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyShapes
{
    [Serializable]
    public abstract class Shape
    {
        public const int PropertyColumnIndex = 1;
        public const int NameIndex = 0;
        public const int FirstPointXIndex = 1;
        public const int FirstPointYIndex = 2;
        public const int SecondPointXIndex = 3;
        public const int SecondPointYIndex = 4;
        public const int ColorIndex = 5;
        public const int ThicknessIndex = 6;

        protected Point firstPoint;
        protected Point secondPoint;
        
        public string name;

        public Shape(Point firstPoint, Point secondPoint, string name)
        {
            this.firstPoint = firstPoint;
            this.secondPoint = secondPoint;
            this.name = name;
        }

        public abstract void Draw(Graphics graphic);
        public abstract void ShowShapeParameters(DataGridView parametersGrid);
        public abstract void ConfirmShapeParametersChange(DataGridView parametersGrid);
    }
}