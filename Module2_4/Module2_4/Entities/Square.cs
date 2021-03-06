﻿using System;

namespace Module2_4.Entities
{
    public class Square : Shape
    {
        public double SideLength { get; set; }

        public override void InitializeByParameter(double parameter)
        {
            SideLength = parameter;
            Perimeter = SideLength * 4;
            Area = Math.Pow(SideLength, 2);
        }

        public override void GetPerimeter(double perimeter)
        {
            InitializeByParameter(perimeter / 4);
        }

        public override void GetArea(double area)
        {
            InitializeByParameter(Math.Sqrt(area));
        }
    }
}