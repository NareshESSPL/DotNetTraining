namespace Tuples
{
    public class TesTuple
    {
        public void Test()
        {
            Tuple<string, int, string> tuple =
                new Tuple<string, int, string>("X", 1, "Z");

            string x = "g";
            //int result;
            //if(int.TryParse(x,out result))
            //or direcctly
            if(int.TryParse(x, out int result))
                Console.WriteLine(result);

        }
        // to return a tuble directly
        public (string,int,string) TestTupleReturn()
        {
            return ("",1,"");
        }

        //or

        public Tuple<string,  int, string> Test2()
        {
            var output = new Tuple<string,int,string>("X", 1, "Z");
            return output;
        }
    }
    public  class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
