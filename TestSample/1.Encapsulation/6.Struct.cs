using System;

namespace Encapsulation
{
    public struct Point
    {
        // Fields
        public int X { get; set; }
        public int Y { get; set; }

        //Cannot have parameterless Constructor if user define a constructor
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        // Method
        public double DistanceFromOrigin()
        {
            X = 12;
            return Math.Sqrt(X * X + Y * Y);
        }

        public override string ToString()
        {
            return $"Point({X}, {Y})";
        }
    }

    public class Program
    {
        public static void Main()
        {
            // Create a Point struct
            Point p1 = new Point(3, 4);

            // Access properties and methods
            Console.WriteLine(p1); // Output: Point(3, 4)
            Console.WriteLine($"Distance from origin: {p1.DistanceFromOrigin()}"); // Output: 5

            // Create a copy (value type behavior)
            Point p2 = p1;
            p2.X = 10; // Changes p2, but not p1
            Console.WriteLine(p1); // Output: Point(3, 4)
            Console.WriteLine(p2); // Output: Point(10, 4)
        }
    }

}
