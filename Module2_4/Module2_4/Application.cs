using System;
using System.Collections.Generic;
using Module2_4.Entities;

namespace Module2_4
{
    public class Application
    {
        public static Circle Circle { get; set; }
        public static Square Square { get; set; }
        public static Triangle Triangle { get; set; }
        private readonly ShapeManager _shapeManager;

        public Application()
        {
            Circle = new Circle {Name = "Circle"};
            Square = new Square {Name = "Square"};
            Triangle = new Triangle {Name = "Triangle"};
            _shapeManager = new ShapeManager();
        }

        public void Run()
        {
            Shape requiredShape = null;
            string shapeData = null;
            List<Shape> shapes = new List<Shape> {Circle, Square, Triangle};

            while (requiredShape == null)
            {
                requiredShape = ChooseShape();
            }

            while (shapeData == null)
            {
                shapeData = ChooseShapeData();
            }

            double squareParameter = _shapeManager.AskParameter(requiredShape);
            requiredShape.InitializeByParameter(squareParameter);
            shapes.Remove(requiredShape);
            string result = "";
            
            switch (shapeData)
            {
                case "perimeter":
                {
                    Console.WriteLine($"{requiredShape.Name} perimeter is: {requiredShape.Perimeter}");
                    
                    foreach (var shape in shapes)
                    {
                        shape.InitializeByPerimeter(requiredShape.Perimeter);
                        result += $"{shape.Name} possible area is: {shape.Area} \n";
                    }

                    Console.WriteLine(result);
                    break;
                }
                case "area":
                {
                    Console.WriteLine($"{requiredShape.Name} area is: {requiredShape.Area}");

                    foreach (var shape in shapes)
                    {
                        shape.InitializeByArea(requiredShape.Area);
                        result += $"{shape.Name} possible perimeter is: {shape.Perimeter} \n";
                    }

                    Console.WriteLine(result);
                    break;
                }
            }
        }

        static Shape ChooseShape()
        {
            Console.Write("Inter the name of shape: circle, triangle or square - ");
            string shapeType = Console.ReadLine();
            Shape requiredShape = null;

            switch (shapeType)
            {
                case "circle":
                {
                    requiredShape = Circle;
                    break;
                }
                case "triangle":
                {
                    requiredShape = Triangle;
                    break;
                }
                case "square":
                {
                    requiredShape = Square;
                    break;
                }
            }

            return requiredShape;
        }

        static string ChooseShapeData()
        {
            Console.Write("Inter perimeter or area - ");
            string consoleData = Console.ReadLine();
            string shapeData = null;

            if (consoleData == "area" || consoleData == "perimeter")
            {
                shapeData = consoleData;
            }

            return shapeData;
        }
    }
}