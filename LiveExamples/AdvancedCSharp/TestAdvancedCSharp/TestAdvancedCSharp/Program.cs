using AdvancedCSharp;

namespace TestAdvancedCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TesExtension tesExtension = new TesExtension();
            tesExtension.Test();

            List<string> list = new List<string>();
            list.Add("A");
            list.Remove("B");
            list.RemoveAt(0);
           
            List<string> list2 = list.ToList();
            list2 = new List<string> { "A", "B", "C"};

            list.AddRange(list2);

            list.ForEach(item => { Console.WriteLine(item); });

            foreach(var item in list) 
            { 
                Console.WriteLine(item);
            }

            Console.WriteLine("Hello, World!");
        }
    }
}
