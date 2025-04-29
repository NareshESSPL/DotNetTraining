namespace PublisherSubscriber
{
    public class DelegateDemo
    {
        public delegate void TestDeligate();

        public void print()
        {
            Console.WriteLine("Printing");

        }

        public void Test()
        {
            TestDeligate test = new TestDeligate(print);

        }

        public void Test(TestDeligate td)
        {
            td();
        }

    }

}
