using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Test
    {
        public void test() 
        {
            IPaymentGateway paymentGateway = new PayPal();
            Allpay allpay = new Allpay(paymentGateway);
            allpay.ProcessPayment(3000);
            allpay.processAnyPayment();
            paymentGateway = new Razorpay();
            allpay = new Allpay(paymentGateway);
            allpay.processAnyPayment();

        }
       
    }
}
