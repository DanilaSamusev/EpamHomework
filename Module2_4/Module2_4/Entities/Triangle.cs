using System;

namespace Module2_4.Entities
{
    public class Triangle : Shape
    {
        public double SideLength { get; set; }
        
        public override void InitializeByParameter(double parameter)
        {
            SideLength = parameter;
            Perimeter = SideLength * 3;
            Area = Math.Pow(SideLength, 2) * Math.Sqrt(3) / 4;
        }

        public override void InitializeByPerimeter(double perimeter)
        {
            InitializeByParameter(perimeter / 3);
        }

        public override void InitializeByArea(double area)
        {
            InitializeByParameter(Math.Sqrt(4 * area / Math.Sqrt(3)));
        }
    }
}