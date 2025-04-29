using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlinePaymentSystem
{
    public class PaymentProcessor
    {
        private readonly IPaymentGateway _paymentGateway;
        public PaymentProcessor(IPaymentGateway paymentGateway)
        {
            _paymentGateway = paymentGateway;
        }
        public void ProcessAnyPayment(decimal amount)
        {
            _paymentGateway.ProcessPayment(amount);
        }
    }
}