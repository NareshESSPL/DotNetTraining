namespace ClassLibrary
{
    public class ActionDelgate
    {
        public void Test()
        {
            Action print = () => Console.WriteLine("Printing lamda");
            print += PrintToFile;
            print += delegate () { Console.WriteLine("Printing Anonymous"); };
            print();
        }

        public void PrintToFile()
        {
            Console.WriteLine("hii");
        }


    }
}
