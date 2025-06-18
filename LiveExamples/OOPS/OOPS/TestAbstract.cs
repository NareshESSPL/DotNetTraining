using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    public abstract class TaxCalculator
    {
        public double CalculateGST(double price, float gstPercent)
        {
            double priceWIthGST = price + (price * (gstPercent / 100));

            return priceWIthGST;
        }

        public abstract double CalculateCess(double price);
    }

    public class TaxCalculatorOdisha : TaxCalculator
    {
        public override double CalculateCess(double price)
        {
            double priceWithCess = price + (price * 0.01);

            return priceWithCess;
        }
    }

    public class TaxCalculatorBihar : TaxCalculator
    {
        public override double CalculateCess(double price)
        {
            double priceWithCess = price + (price * 0.01);

            return priceWithCess;
        }
    }


    public class Invoice
    {
        TaxCalculator taxCalculator;

        public decimal CalculateReturn(decimal price, decimal discount)
        {
            return price - discount;
        }

        public decimal CalculateReturn(decimal price, decimal discount, decimal employeeDiscount)
        {
            return price - discount - employeeDiscount;
        }

        public Invoice(string name)
        {
            switch (name)
            {
                case "Odisha":
                    taxCalculator = new TaxCalculatorOdisha();
                    break;

                default:
                    taxCalculator = new TaxCalculatorBihar();
                    break;
            }
        }

        public void CalculateFinalPrice()
        {
            var price = 100;

            var priceWithGST = taxCalculator.CalculateGST(price, 18);

            var finalPrice = (decimal)taxCalculator.CalculateCess(priceWithGST);

            var discountedPrice = CalculateReturn(finalPrice, 100);

            discountedPrice = CalculateReturn(finalPrice, 100, 10);

            Console.WriteLine(discountedPrice);
        }
    }

}
