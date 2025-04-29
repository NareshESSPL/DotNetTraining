using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsConcept
{
    public class Order
    {
        public int OrderId { get; set; }
        public string ItemName { get; set; }
        public DateTime OrderDate { get; set; }
    }

    public class TestOrder
    {
        //int x = 0;
        Order order= new Order();
        public void Test(Order inputOrder)
        {
            Console.WriteLine(inputOrder.ItemName);
            Console.WriteLine(inputOrder.OrderId);
            Console.WriteLine(inputOrder.OrderDate);
        }
        public void CallTest()
        {
            Order inputOrder = new Order();
            inputOrder.ItemName = "test item";
           
            Test(inputOrder);
        }
    }
}
