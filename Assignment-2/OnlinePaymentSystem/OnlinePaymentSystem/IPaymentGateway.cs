namespace OnlinePaymentSystem
{
    public interface IPaymentGateway
    {
       void ProcessPayment(decimal amount);
    }
}
