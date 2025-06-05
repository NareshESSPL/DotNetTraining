using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public interface IPaymentGateway
    {
        
        public  void ProcessPayment(decimal input);
    }
    //PayPal, Stripe, and Razorpay
    public class PayPal : IPaymentGateway
    {
        
        public decimal  principal = 1000;
        public decimal rot = 20;
        public decimal time = 5;
        public void ProcessPayment(decimal payment)
        {
            decimal Amount = principal * rot * time/100;
            decimal finalAmount = payment + Amount;
            Console.WriteLine("The final amount of paypal will be:"+finalAmount);
        }
    }
    public class  Razorpay : IPaymentGateway
    {
        public decimal principal = 5000;
        public decimal rot = 50;
        public decimal time = 15;
        public void ProcessPayment(decimal payment)
        {
            decimal Amount = principal * rot * time/100;
            decimal finalAmount = payment + Amount;
            Console.WriteLine("The final amount of RazorPay will be:" + finalAmount);
        }
    }
    public class Allpay : IPaymentGateway
    {
        readonly IPaymentGateway ipg;
        public decimal principal;
        public decimal rot;
        public decimal time;
        public Allpay()
        {
            principal = 3000;
            rot = 50;
            time = 8;
        }
        public Allpay(IPaymentGateway gateway)
        {
            ipg = gateway;
        }
        public void ProcessPayment(decimal payment)
        {
            decimal Amount = principal * rot * time/100;
            decimal finalAmount = payment + Amount;
            Console.WriteLine("The final amount of Allpay will be:" + finalAmount);
        }
        public void processAnyPayment()
        {
            ipg.ProcessPayment(2000);
        }
    }
}
