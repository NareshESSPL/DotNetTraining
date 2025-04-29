using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAdvanceCSharp
{
    public interface IPaymentGateway
    {
        void ProcessPayment(decimal amount);
    }
    public class PayPalGateway : IPaymentGateway
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processed ${amount} using PayPal.");
        }
    }

    public class RazorPayGateway : IPaymentGateway
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processed ${amount} using RazorPay.");
        }
    }
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
