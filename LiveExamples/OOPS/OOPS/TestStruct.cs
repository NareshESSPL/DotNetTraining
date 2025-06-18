using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    public class TestStruct
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
        }

        public class TestSctruct
        {
            public void Test()
            {
                Point p = new Point();
                p.X = 12;

                Console.WriteLine(p.X);


                Point p2 = new Point(1, 2);
                Console.WriteLine(p2.DistanceFromOrigin());
            }
        }
    }
}
