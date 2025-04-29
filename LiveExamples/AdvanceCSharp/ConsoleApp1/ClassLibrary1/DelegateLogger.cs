using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublisherSubscriber
{
    public delegate void Log(string Message);

    public class Business
    {
        public Log logger;
            
        public Business(Log _logger)
        {
            logger = _logger;
        }

        public void DoProcess()
        {
            string[] customers = new string[] { "mahesh", "Suresh", "Naresh" };
            foreach (string customer in customers)
            {
                logger("Customer Added" + customer);
            }
        }
    }

    public class TestLogger
    {
        public void Test()
        {
            Log logger = new Log(WriteToFile);
            Business business = new Business(logger);
            business.DoProcess();
        }
        
        public void WriteToFile(string message)
        {
            Console.WriteLine("Write to file" + message);
        }
    }

}
