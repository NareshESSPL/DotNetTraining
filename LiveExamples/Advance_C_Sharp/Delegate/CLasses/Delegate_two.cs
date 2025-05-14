using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceCSharp
{
    public delegate void Log(string message);
    public  class BussinessLogic
    {
        public Log logger;

        public BussinessLogic(Log obj)
        {
            logger = obj;
        }

        public void Process()
        {
            string[] customername = new string[] { "Nik", "Jean", "Lokesh" };

            for (int i = 0; i < customername.Length; i++)
            {
                logger("Added to deleget:" + customername[i]);
            }
        }

    }

    public class Testing
    {
       public void Test()
        {
             Log log_obj = new Log(Method1);
             log_obj += Method2;
             BussinessLogic obj = new BussinessLogic(log_obj);

            obj.Process();            
        }

        public void Method1(string msg)
        {
            Console.WriteLine("hii"+msg); 
        }

        public void Method2(string msg)
        {
            Console.WriteLine("how are you -"+msg);
        }
    }
}
