using System;

namespace Module2_4.Entities
{
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public override void InitializeByParameter(double parameter)
        {
            Radius = parameter;
            Perimeter = 2 * Math.PI * Radius;
            Area = Math.PI * Math.Pow(Radius, 2);
        }

        public override void GetPerimeter(double perimeter)
        {
            InitializeByParameter(perimeter / (2 * Math.PI));
        }

        public override void GetArea(double area)
        {
            InitializeByParameter(Math.Sqrt(area / Math.PI));
        }
    }
}