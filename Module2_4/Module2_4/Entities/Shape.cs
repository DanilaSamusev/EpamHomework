namespace Module2_4.Entities
{
    public abstract class Shape
    {
        public double Area { get; set; }
        public double Perimeter { get; set; }
        public string Name { get; set; }
        public abstract void InitializeByParameter(double parameter);
        public abstract void GetPerimeter(double perimeter);
        public abstract void GetArea(double area);
    }
}