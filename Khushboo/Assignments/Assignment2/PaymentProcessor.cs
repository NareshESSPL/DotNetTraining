
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystem
{
    public class PaymentProcessor
    {
        private readonly IPaymentGateway _gateway;

        // Constructor Injection
        public PaymentProcessor(IPaymentGateway gateway)
        {
            _gateway = gateway;
        }

        public void ProcessAnyPayment(decimal amount)
        {
            _gateway.ProcessPayment(amount);
        }
    }
}

