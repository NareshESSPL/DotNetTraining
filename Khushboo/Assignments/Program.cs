using System;
using Assignments.Assignment1;
using PaymentSystem;
using VehicleSystem;
namespace Assignments
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp1 = new PermanentEmployee() { Id = 1, Name = "Alice", BasicPay = 30000 };
            Employee emp2 = new ContractEmployee() { Id = 2, Name = "Bob", HourlyRate = 200, HoursWorked = 80 };

            emp1.ShowDetails();
            Console.WriteLine($"Salary: {emp1.CalculateSalary()}\n");

            emp2.ShowDetails();
            Console.WriteLine($"Salary: {emp2.CalculateSalary()}\n");

            emp1.GenerateReport();
            emp1.GenerateReport("HR");
            emp1.GenerateReport(1);


            //Assignment 2
            // Create PayPal payment processor
            var paypal = new PaymentProcessor(new PaypalGateway());
            paypal.ProcessAnyPayment(500);

            // Create Razorpay payment processor
            var razorpay = new PaymentProcessor(new RazorpayGateway());
            razorpay.ProcessAnyPayment(1000);

            //Assignment3
            Vehicle v1 = new Vehicle("Honda City");
            v1.ShowDetails();

            // Using constructor2
            Vehicle v2 = new Vehicle("Tata Nexon", "Electric");
            v2.ShowDetails();

            // Using constructor3 in derived class
            LimitedEditionVehicle v3 = new LimitedEditionVehicle("Mahindra Thar", "Diesel");
            v3.ShowLimitedEditionFeature();
        }
    }
}

