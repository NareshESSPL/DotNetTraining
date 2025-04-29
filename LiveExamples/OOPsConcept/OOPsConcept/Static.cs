using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsConcept
{
   public static class StaticDemo
    {
        public static string message { get; set; }

        public static void DisplayMessage()
        {
            Console.WriteLine(message);
        }

        
    }

    public class Test1
    {
        public void RunTest()
        {
            StaticDemo.message = "abc";
        }
    }

    public class Test2
    {
        public void RunTest()
        {
            StaticDemo.message = "cba";
        }
    }

}
