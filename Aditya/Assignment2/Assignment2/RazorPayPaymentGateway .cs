using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace OnlinePaymentSystem
{
    public class RazorPayPaymentGateway : IPaymentGateway
    {
        public void ProcessPayment(decimal amount)
        {
            CultureInfo indianCulture = new CultureInfo("en-IN");
            Console.WriteLine($"Processing payment of {amount.ToString("C", indianCulture)} through RazorPay.");
        }

    }
}