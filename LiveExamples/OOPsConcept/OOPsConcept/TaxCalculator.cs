//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace OOPsConcept
//{
//    public abstract class TaxCalculator
//    {
//        public double CalculateGST(double Price, float getPercentage)
//        {
//            double PriceWithGST = Price * (Price * (getPercentage / 100));
//            return PriceWithGST;
//        }
//        public abstract double CalculateCess(double Price);
//    }
//    public class TaxCalculationOdisha : TaxCalculator
//    {
//        public override double CalculateCess(double Price)
//        {
//            double PriceWithCess = Price * (Price * 0.01);
//            return PriceWithCess;
//        }
//    }
//    public class Invoice
//    {
//        TaxCalculator taxCalculator;
//        public Invoice(string name)
//        {
//            switch (name)
//            {
//                case "Odisha":
//                    taxCalculator = new TaxCalculator();
//                    break;

//                default:
//                    taxCalculator = new TaxCalculator();
//                    break;
//            }
//        }
//        public void CalculateFinalPrice()
//        {
//            var price = 100;
//            var priceWithGST = taxCalculator.CalculateGST(price, 10);
//        }
//    }
//}
