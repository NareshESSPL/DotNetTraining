using System.Reflection.Metadata;
using ClassLibrary;

namespace Class_level_generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var processor = new MultiGenerics<Order>();
        }
    }
}
