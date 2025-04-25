using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSBaseTypes
{
    public interface IModel
    {

    }

    public class Order : IModel
    {
        public int OrderId { get; set; }
        public string ItemName { get; set; }
        public DateTime OrderDate { get; set; }
    }

    public class Customer : IModel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class TestbaseTypes
    {
        public void Test()
        {
            IModel objOrder = new Order();

            IModel objCustomer = new Customer();

            CallTest3(objOrder);

            CallTest3(objCustomer);

        }

        private void CallTest3(IModel obj)
        {
        }
    }
}
