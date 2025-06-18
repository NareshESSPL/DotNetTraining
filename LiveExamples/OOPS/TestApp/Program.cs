using Businesslayer;
using OOPS;
using OOPSDebug;

namespace TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BaseClass baseClass = new BaseClass();
            //baseClass.ConnectToDB();

            //TestbaseTypes testbaseTypes = new TestbaseTypes();
            //testbaseTypes.Test();

            TestExec testExec = new TestExec();
            testExec.TestDB();

            Console.WriteLine("Hello, World!");
        }
    }
}
