using Assignment2;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Select Payment Gateway: 1 for PayPal, 2 for RazorPay");
            string choice = Console.ReadLine();

            IPaymentGateway gateway = choice switch
            {
                "1" => new PayPalGateway(),
                "2" => new RazorPayGateway(),
                _ => throw new InvalidOperationException("Invalid choice")
            };

            Console.WriteLine("Enter amount to pay:");
            decimal amount = decimal.Parse(Console.ReadLine());

            PaymentProcessor processor = new PaymentProcessor(gateway);
            processor.ProcessAnyPayment(amount);
        }
    }

}
