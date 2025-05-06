using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharp
{
    public delegate void Log(string message);
    public class Business
    {
        public Log logger;
        public Business(Log _logger)
        {
            logger = _logger;
        }

        public void DoProcess()
        {
            string[] customers = new string[] { "Naresh", "Suresh", "Mahesh" };

            for (int i = 0; i < customers.Length; i++)
            {
                logger("Customer added :" + customers[i]);
            }
        }
    }

    public class TestLogger
    {
        public void Test()
        {
            Log logger = new Log(WriteToFile);

            //Log logger = WriteToFile;

            //Log logger =
            //    (string message) =>
            //    {
            //    Console.WriteLine("Anonymous call" + message);
            //    };

            //Log logger =
            //    (string message) => Console.WriteLine("Anonymous call" + message);


            logger += WriteToDB;

            Business business = new Business(logger);

            business.DoProcess();
        }

        public void WriteToFile(string message)
        {
            Console.WriteLine("Write to file : " + message);
        }

        public void WriteToDB(string message)
        {
            Console.WriteLine("Write to db : " + message);
        }

        public void WriteToAPI(string message)
        {
            Console.WriteLine("Write to db : " + message);
        }
    }
}
