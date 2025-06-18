using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    public class Order
    {
        public int OrderId { get; set; }
        public string ItemName { get; set; }
        public DateTime OrderDate { get; set; }
    }

    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class TestOrder
    {
        int x = 0;
        Order order = new Order();
        public void Test(Order inputOrder)
        {
            Console.WriteLine(inputOrder.ItemName);
            Console.WriteLine(inputOrder.OrderId);
            Console.WriteLine(inputOrder.OrderDate);

            inputOrder.ItemName = "No-order";
        }

        public void CallTest()
        {
            Order inputOrder = new Order();
            inputOrder.ItemName = "test-item";

            Test(inputOrder);

            Console.WriteLine(inputOrder.ItemName);
        }

        public void CallTest2() 
        { 
           var objOrder = new Order();

           var objCustomer = new Customer();

            CallTest3(objOrder);

            CallTest3(objCustomer);

            CallTest3(3);
        }

        private void CallTest3(Object obj)
        {
            if (obj.GetType() == typeof(Order))
                Console.WriteLine("This is a order object");
        }
    }
}
