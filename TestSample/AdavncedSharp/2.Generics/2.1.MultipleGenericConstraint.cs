using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdavncedCSharp
{
    class DualGeneric<T1, T2>
        where T1 : class               // T1 must be a reference type
        where T2 : struct              // T2 must be a value type
    {
        public T1 ReferenceItem { get; set; }
        public T2 ValueItem { get; set; }

        public DualGeneric(T1 refItem, T2 valItem)
        {
            ReferenceItem = refItem;
            ValueItem = valItem;
        }

        public void Display()
        {
            Console.WriteLine($"Reference Type: {ReferenceItem}");
            Console.WriteLine($"Value Type: {ValueItem}");
        }
    }

    public class TestDualGeneric()
    {
        public void Test()
        {
            DualGeneric<string, int> obj = new DualGeneric<string, int>("Hello", 42);
            obj.Display();
        }
    }
}
