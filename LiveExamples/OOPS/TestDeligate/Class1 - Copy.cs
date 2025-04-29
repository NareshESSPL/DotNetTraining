namespace TestDeligate
{
    public class deltest
    {
        public delegate void test();

        //public void Print()
        //{
        //    Console.WriteLine("Printing");
        //}

        //public void AttachMethod()
        //{
        //    test t = new test(Print);
        //}

        public void Testt(test td)
        {
            td();
        }
    }
}
