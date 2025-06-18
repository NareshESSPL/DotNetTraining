using PropertyTest;

namespace TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestProperty testProperty = new TestProperty();

            testProperty.SetFullName("111");
            Console.WriteLine(testProperty.GetFullName());

            testProperty.LastName = "111";
            Console.WriteLine(testProperty.LastName);

            Console.WriteLine("Hello, World!");
        }
    }
}
