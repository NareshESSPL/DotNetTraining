using ClassLibrary;

namespace ActionDelegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////ActionDelgate del  = new ActionDelgate();
            ////del.Test();
            ////Console.WriteLine("Hello, World!");

            ////calling action delegate  generic 

            //var obj = new ClassLibrary.ActionDelegateGeneric();

            //obj.Test("Hello Nitish!");
            //obj.Test(123); // works with int as well


            //var obj = new ClassLibrary.ActiondelgateWithgenerics();

            //Console.WriteLine("Calling TestAction():");
            //obj.TestAction();

            //Console.WriteLine("\nCalling TestActionAsInput():");
            //obj.TestActionAsInput();


            var obj = new Function_delegates();

            Console.WriteLine("Calling TestFuncAsInput2():");
            obj.TestFuncASInput2();

        }
    }
}
