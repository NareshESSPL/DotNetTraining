using OnlinePaymentSystem;
using System.Globalization;
namespace OPSTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Choose Payment Gateway:");
            Console.WriteLine("1. PayPal");
            Console.WriteLine("2. Razorpay");
            Console.Write("Enter choice (1 or 2): ");

            string choice = Console.ReadLine();
            IPaymentGateway paymentGateway;
            switch (choice)
            {
                case "1":
                    paymentGateway = new PayPalPaymentGateway();
                    break;
                case "2":
                    paymentGateway = new RazorPayPaymentGateway();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Defaulting to PayPal.");
                    paymentGateway = new PayPalPaymentGateway();
                    break;
            }

            PaymentProcessor processor = new PaymentProcessor(paymentGateway);

            Console.Write("Enter amount to process: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                processor.ProcessAnyPayment(amount);
            }
            else
            {
                Console.WriteLine("Invalid amount entered.");
            }

            Console.ReadLine();
        }
    }
}