using System;
using Module2_4.Entities;

namespace Module2_4
{
    public class ShapeManager
    {
        public double AskParameter(Shape shape)
        {
            double shapeParameter = 0;
            
            if (shape is Triangle)
            {
                shapeParameter = AskTriangleParameters();
            }

            if (shape is Square)
            {
                shapeParameter = AskSquareParameters();
            }

            if (shape is Circle)
            {
                shapeParameter = AskCircleParameters();
            }

            return shapeParameter;
        }
        
        private double AskTriangleParameters()
        {
            return StringParser.GetDouble("triangle side length:");
        }
        
        private double AskSquareParameters()
        {
            return StringParser.GetDouble("square side length:");
        }
        
        private double AskCircleParameters()
        {
            return StringParser.GetDouble("circle radius:");
        }
    }
}