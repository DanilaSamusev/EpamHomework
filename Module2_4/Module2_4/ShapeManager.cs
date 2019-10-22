using System;
using Module2_4.Entities;

namespace Module2_4
{
    public class ShapeManager
    {
        public double AskParameter(Shape shape)
        {
            double shapeParameter = 0;
            
            switch (shape)
            {
                case Triangle _:
                    shapeParameter = AskTriangleParameters();
                    break;
                case Square _:
                    shapeParameter = AskSquareParameters();
                    break;
                case Circle _:
                    shapeParameter = AskCircleParameters();
                    break;
            }

            return shapeParameter;
        }
        
        private double AskTriangleParameters()
        {
            return DataParser.GetDouble("triangle side length:");
        }
        
        private double AskSquareParameters()
        {
            return DataParser.GetDouble("square side length:");
        }
        
        private double AskCircleParameters()
        {
            return DataParser.GetDouble("circle radius:");
        }
    }
}