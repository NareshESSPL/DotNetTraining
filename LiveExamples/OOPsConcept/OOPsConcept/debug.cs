using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsConcept
{
    public interface IModel123
    {
        public void Iterate();
    }

    public class OOrder : IModel123
    {
        public int OrderId { get; set; }
        public string ItemName { get; set; }
        public DateTime OrderDate { get; set; }

        public void Iterate()
        {
            string[] strArr = new string[4] { "sdbsa", "sdfsd", "sdfsdf", "sfdsf" };

            for (int i = 0; i <10; i++)
            {
                Console.WriteLine(strArr[i]);
            }
        }
    }

    public class Customer : IModel123
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime CreatedDate { get; set; }

        public void Iterate()
        {
            int[] intArr = new int[4] { 111, 1432, 23432, 2344 };

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(intArr[i]);
            }
        }
    }

    public class TestbaseTypes
    {
        public string AppName { get; set; }
        public void Test()
        {
            IModel123 objOrder = new OOrder();

            IModel123 objCustomer = new Customer();

            CallTest3(objOrder);

            CallTest3(objCustomer);

        }

        private void CallTest3(IModel123 obj)
        {
            obj.Iterate();
        }
    }
}
