using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    public abstract class Shape
    {
        // Abstract method (no implementation)
        public abstract double GetArea();

        // Concrete method (implemented)
        public void Display()
        {
            Console.WriteLine($"The area of the shape is: {GetArea()}");
        }
    }

    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        // Override the abstract method
        public override double GetArea()
        {
            return Math.PI * radius * radius;
        }
    }

    public class Rectangle : Shape
    {
        private double length;
        private double width;

        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
        }

        // Override the abstract method
        public override double GetArea()
        {
            return length * width;
        }
    }

    //class Program
    //{
    //    static void Main()
    //    {
    //        // Derived class instances
    //        Shape circle = new Circle(5);
    //        Shape rectangle = new Rectangle(4, 6);

    //        // Calling the concrete method
    //        circle.Display();    // Output: The area of the shape is: 78.53981633974483
    //        rectangle.Display(); // Output: The area of the shape is: 24
    //    }
    //}

}
