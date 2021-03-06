﻿using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MyShapes
{
    [DataContract]
    [KnownType(typeof(Square))]
    [KnownType(typeof(Triangle))]
    [KnownType(typeof(Rectangle))]
    [KnownType(typeof(Line))]
    [KnownType(typeof(Ellipse))]
    [KnownType(typeof(Circle))]
    [XmlInclude(typeof(Square))]
    [XmlInclude(typeof(Triangle))]
    [XmlInclude(typeof(Rectangle))]
    [XmlInclude(typeof(Line))]
    [XmlInclude(typeof(Ellipse))]
    [XmlInclude(typeof(Circle))]
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

        [DataMember]
        public Point firstPoint;
        [DataMember]
        public Point secondPoint;
        [DataMember]
        public int color;
        [DataMember]
        public int thickness;
        [DataMember]
        public string name;

        public Shape() { }

        public Shape(Point firstPoint, Point secondPoint, string name, Color color, int thickness)
        {
            this.firstPoint = firstPoint;
            this.secondPoint = secondPoint;
            this.name = name;
            this.color = color.ToArgb();
            this.thickness = thickness;
        }

        public abstract void Draw(Graphics graphic);
        public abstract void ShowShapeParameters(DataGridView parametersGrid);
        public abstract void ConfirmShapeParametersChange(DataGridView parametersGrid);
    }
}