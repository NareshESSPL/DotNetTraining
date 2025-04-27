using ExceptionHandling;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ErroMessageBuilder erroMessageBuilder = new ErroMessageBuilder();
            erroMessageBuilder.TestInnerException(10);

            Console.WriteLine("Hello, World!");
        }
    }
}
