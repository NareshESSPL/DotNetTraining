using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    public class Shape
    {
        public virtual decimal Area(decimal[] inputs)
        {
            return inputs[0] * inputs[1];
        }
    }
    public class Rectangle : Shape
    {
    }

    public class Circle : Shape
    {
        public override decimal Area(decimal[] inputs)
        {
            return (3.14m) * inputs[0] * inputs[0];
        }

    }

    public class TestShape
    {
        public  void Test()
        {
            Rectangle rct = new Rectangle();

            var rctArea = rct.Area(new decimal[] { 1, 2 });

            Console.WriteLine(rctArea);


            Circle crc = new Circle();

            var crcArea = crc.Area(new decimal[] { 1, 2 });


            Console.WriteLine(crcArea);
        }
    }
}
