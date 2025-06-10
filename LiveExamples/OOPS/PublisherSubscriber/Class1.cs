namespace PublisherSubscriber
{
    public delegate void Log(String message);
    public class Business
    {
        public Log logger;

        public Business(Log _looger)
        {
            logger = _looger;
        }

        public void DoProcess()
        {
            String[] Customers = { "Naresh", "Suresh", "Mahesh" };
            for(int i=0;i<Customers.Length;i++)
            {
                logger("Customer added :"+Customers[i]);
            }
        }
    }

    public class TestLogger
    {
        public void Test()
        {
            Log looger = new Log(WriteToFile);
            looger += WriteToDb;
            Business  business=new Business(looger);
            business.DoProcess();
        }

        public void WriteToFile(String message)
        {
            Console.WriteLine("Write to File :"+message);
        }

       
        public void WriteToDb(String message)
        {
            Console.WriteLine("Write to Db :"+message);
        }
    }
}
