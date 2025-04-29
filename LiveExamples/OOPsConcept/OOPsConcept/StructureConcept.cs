using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsConcept
{
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }


        public Point(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public double DistanceFromOrigin()
        {
            X = 12;
            return Math.Sqrt(X * X + Y * Y);
        }
    }

    public class TestStruct()
    {
        public void Test()
        {
            Point p = new Point(12, 5);

            Console.WriteLine(p.ToString());
        }



        //public void CallTest2()
        //{
        //    var objOrder = new Order();
        //    var objCustomer = new Customer();

        //}

    }
}
