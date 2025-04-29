namespace Delegate
{


      public delegate void Log(string message);
        public class Delegate_two
        {
            public Log logger;

            public Delegate_two(Log obj)
            {
                logger = obj;
            }

        }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
