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
            Console.WriteLine($"[PayPal] Payment of ₹{amount} processed successfully.");
        }
    }

    public class RazorPayGateway : IPaymentGateway
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"[RazorPay] Payment of ₹{amount} processed successfully.");
        }
    }

    public class PaymentProcessor
    {
        private readonly IPaymentGateway _paymentGateway;

        // Constructor injection
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
