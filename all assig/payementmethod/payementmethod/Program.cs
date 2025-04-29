using System;

namespace PaymentProcessingSystem
{
    
    public interface IPaymentGateway
    {
        void ProcessPayment(decimal amount);
    }

    
    public class PaypalPaymentGateway : IPaymentGateway
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing PayPal payment of ${amount}");
        }
    }

    
    public class RazorpayPaymentGateway : IPaymentGateway
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing Razorpay payment of ${amount}");
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

     
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select Payment Gateway:");
            Console.WriteLine("1. PayPal");
            Console.WriteLine("2. Razorpay");
            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();

            IPaymentGateway paymentGateway;

            if (choice == "1")
            {
                paymentGateway = new PaypalPaymentGateway();
            }
            else if (choice == "2")
            {
                paymentGateway = new RazorpayPaymentGateway();
            }
            else
            {
                Console.WriteLine("Invalid choice");
                return;
            }

            PaymentProcessor processor = new PaymentProcessor(paymentGateway);

            Console.Write("Enter amount to pay: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                processor.ProcessAnyPayment(amount);
            }
            else
            {
                Console.WriteLine("Invalid amount entered.");
            }
        }
    }
}
