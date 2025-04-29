namespace OnlinePaymentSystem
{
    public interface IPaymentGateway
    {

        public void ProcessPayment(decimal status);

    }


    public class Paypal : IPaymentGateway
    {

        public void ProcessPayment(decimal status)
        {
            Console.WriteLine($"Payment Status via Paypal:{status}");
        }
    }

    public class RazorPay : IPaymentGateway
    {

        public void ProcessPayment(decimal status)
        {
            Console.WriteLine($"Payment Status via RazorPay:{status}");
        }

    }

    public enum GateWayOps
    {
        None,
        PayPal,
        RazorPay
    }

    public class ClientPaymentGateway
    {

        internal readonly IPaymentGateway IService;

        public ClientPaymentGateway(IPaymentGateway iService)
        {
            IService = iService;

        }

        public void ProcessPayment(decimal status)
        {
            IService.ProcessPayment(status);
        }


        public void ProcessAnyPayment(GateWayOps gateWayOps)
        {
            IPaymentGateway paymentGateway;

            switch (gateWayOps)
            {
                case GateWayOps.PayPal:
                    paymentGateway = new Paypal();
                    paymentGateway.ProcessPayment(1);
                    break;

                case GateWayOps.RazorPay:
                    paymentGateway = new RazorPay();
                    paymentGateway.ProcessPayment(1);
                    break;
            }

        }

    }

}
