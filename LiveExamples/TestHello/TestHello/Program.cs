using d = DataMover;
using n1 = TestNamespace1;
using n2 = TestNamespace2;

namespace TestHello
{
    internal class Program
    {
        static void Main(string[] args)
        {
            d.DataMover mw = new d.DataMover();
            var isSucess = mw.MoveData("Consumer", "ConsumerSummary");

            n1.Logger logger = new n1.Logger();
            n2.Logger logger2 = new n2.Logger();

            int x = 0;

            Int32 y = 0;

            var z = 12;

            int h;

            h = 32;

            var tempInt = 1;

            long a = 12;

            Int64 b = 12;

            var tempLong = 1L;

            var tempFlaot = 1.2F;

            var tempDecimal = 12.889M;

            var tempSeprator = 100_000.12_234F;

            int Maxvalue = Int32.MaxValue;
            int Maxvalue1 = int.MaxValue;
            int Minvalue1 = int.MinValue;

            //be default 0
            int testInteger;

            string testStr;
            testStr = "hello";

            string testStr1 = "hello";

            String testStr3 = "hello";


            //default is null
            int? testNullInt;
            testNullInt = null;
            testNullInt = 90;

            Nullable<Int32> testNullableInt;
            testNullableInt = null;

            bool testBoolType;
            testBoolType = true;

            bool? testNullableBool;
            testNullableBool = null;
            testNullableBool = false;

            Boolean testBoolean2 = false;



            Console.WriteLine("Hello, World!" + args[0]);

            Console.ReadLine();
        }

        public void ForLoop()
        {
            int x = 0;
            for (x = 0; x < 10; x++)
            {
                Console.WriteLine(x);
            }

            x = 0;
            for (; x < 10;)
            {
                Console.WriteLine(x);
                x++;
            }

            x = 0;
            while (x < 10)
            {
                Console.WriteLine(x);

                x++;
            }

            x = 10;
            do
            {
                Console.WriteLine(x);
            }
            while (x < 10);

            x = 0;
            while (x < 10)
            {
                if (x % 2 == 0)
                    Console.WriteLine(x);
            }

            x = 0;
            while (x < 10)
            {
                switch (x)
                {
                    case 0:
                        Console.WriteLine("0");
                        break;

                    case 1:
                        Console.WriteLine("1");
                        break;

                    default:
                        Console.WriteLine("Other");
                        break;
                }
            }

            int[] sort = { 21321, 23432432, 484474, 238348, 363533353, 327123623, 373373, 373763, 336336, 36763 };

            int ternaryTest = 10;

            string output = ternaryTest > 10 ? "greater than 20" : "smaller";

            int? testNullCoa = null;
            int output3 = testNullCoa ?? 80;

            if (testNullCoa == null)
                output3 = 80;
            else
                output3 = (int)testNullCoa;

        }


    }
}
