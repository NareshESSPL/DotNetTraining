namespace Assignment2
{

    public interface IPaymentGateway
    {
        void ProcessPayment(decimal amount);
    }
    public class PayPalGateway : IPaymentGateway
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine("Processed payment of " + amount + " via PayPal.");
        }
    }

    public class RazorPayGateway : IPaymentGateway
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine("Processed payment of " + amount + "  via RazorPay.");
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

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose Payment Gateway: 1 for PayPal, 2 for RazorPay");
            int choice = int.Parse(Console.ReadLine());

            IPaymentGateway paymentGateway;

            if (choice == 1)
            {
                paymentGateway = new PayPalGateway();
            }
            else if (choice == 2)
            {
                paymentGateway = new RazorPayGateway();
            }
            else
            {
                throw new ArgumentException("Invalid choice.");
            }

            PaymentProcessor paymentProcessor = new PaymentProcessor(paymentGateway);

            Console.WriteLine("Enter payment amount:");
            decimal amount = decimal.Parse(Console.ReadLine());

            paymentProcessor.ProcessAnyPayment(amount);

            Console.WriteLine("Payment processing complete.");
        }
    }
}
