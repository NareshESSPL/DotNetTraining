using OOPsConcept;
namespace ConsoleAppForOOPs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BaseClass baseClass = new BaseClass();
            //baseClass.Validate();
            //TestObejectCopy toc = new TestObejectCopy();
            //toc.Test();
            //TestOverride Tov = new TestOverride();
            //Tov.Test();
            //TestShape ts = new TestShape();
            //ts.Test();
            //TestOrder testOrder = new TestOrder();
            //testOrder.CallTest
            //TestStruct testStruct = new TestStruct();
            //testStruct.Test();
            //ItemTypeOps it = new ItemTypeOps();
            //it.PrintItemTyype(2);
            //TestbaseTypes testBase = new TestbaseTypes();
            //testBase.Test();
            //TestExec loop = new TestExec();


            //loop.Exce();
            //TestExecc testExecc = new TestExecc();
            //testExecc.TestDB();

            //Console.WriteLine("Press any key to exit...");
            //Console.ReadKey();
            //UserValidation userValidation = new UserValidation();

            //try
            //{
                
            //    userValidation.Test(" ");
            //}
            //catch (CustomException ex)
            //{
                
            //    Console.WriteLine($"Caught custom exception: {ex.Message}");
            //}
            Test1 obj1 = new Test1();
            obj1.RunTest();
            obj1 = null;
            Console.WriteLine(StaticDemo.message);
            Test2 obj2 = new Test2();
            obj2.
                RunTest();
            obj2 = null;
            Console.WriteLine(StaticDemo.message);

        }
    }
}
