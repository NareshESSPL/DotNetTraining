using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsConcept
{
    public class Shape
    {
        public virtual decimal Area(decimal[] inputs)
        {
            return inputs[0] * inputs[1];
        }
    }
    public class  Rectangle : Shape
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
        public void Test()
        {
            Rectangle rec = new Rectangle();
            Circle c = new Circle();
            Console.WriteLine(rec.Area([10, 20]));
            Console.WriteLine(c.Area([10]));
        }
    }
}
