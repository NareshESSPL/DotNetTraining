//namespace ClassLibrary
//{
//    public delegate double Show(String StockNames);
//    public class StocksLogic
//    {
//        public  Show Show_obj;

//        public StocksLogic(Show obj) 
//        {
//            Show_obj = obj;
//        }

//        public void Process(string ComapanyName)
//        {
//             //string[] ComapanyName = new string[] {"Tata","Mahindra" };
//            //var comapny = Show_obj("Tata");
//            //Console.WriteLine(comapny);
//            //for (int i= 0;i < ComapanyName.Length;i++) {
//                Show_obj(ComapanyName );
//            //}
//        }
//    }

//    public class Testing {

//        public double Zerodha(string ComapanyName)
//        {
//            var price = 0;

//            if(ComapanyName == "Tata")
//            {
//                price = 100;
//            }else if(ComapanyName == "Mahindra")
//            {
//                price = 150;
//            }

//            return price;
//        }

//        public double Grow(string ComapanyName)
//        {
//            var price = 0;

//            if (ComapanyName == "Tata")
//            {
//                price = 101;
//            }
//            else if (ComapanyName == "Mahindra")
//            {
//                price = 151;
//            }

//            return price;
//        }

//        public void test()
//        {
//            //attaching del obj with methods
//            Show del = new Show(Zerodha);
//            del += Grow;

//            StocksLogic obj = new StocksLogic(del);

//            del.Process("Tata");


//        }


//    }

//}


//special naru code


namespace ClassLibrary
{
    public delegate float stockshower(String Message);
    internal class StockManager
    {
        public stockshower stockshower;
        public StockManager(stockshower _stockshower)
        {
            stockshower = _stockshower;
        }

        public void Print(String comp)
        {
            var price = stockshower(comp);

            Console.WriteLine(price);
        }
    }

    public class Tester
    {
        public void Test()
        {
            stockshower stockshowerobj = new stockshower(GetStockPriceFromNifty);
            stockshowerobj += GetStockPriceFromBSE;

            StockManager stockshowerr = new StockManager(stockshowerobj);

            stockshowerr.Print("Zerodha");
        }

        public float GetStockPriceFromNifty(string comp)
        {
            String[] copms = { "Zerodha", "Bse", "Nse" };

            foreach (String cmp in copms)
            {
                if (cmp == comp)
                    return 101f;
            }

            return 1200f;
        }

        public float GetStockPriceFromBSE(string comp)
        {
            String[] copms = { "Zerodha", "Bse", "Nse" };

            foreach (String cmp in copms)
            {
                if (cmp == comp)
                    return 134f;
            }

            return 1200f;
        }
    }

    public class Testing()
    {
        public static void Main()
        {
            Tester tester = new Tester();
            tester.Test();
        }
    }
}

