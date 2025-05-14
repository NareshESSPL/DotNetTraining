using System.Globalization;
using System.Text;

namespace ConsoleApp1
{
    
    public class String_functions 
    {
        string[] words = { "hello", "World", "!" };
        public void test()
        {
            Console.WriteLine(String.Join("_", words));
        }

        public static void DateTime_manipulation()
        {
            #region DateTime

            DateTime date = DateTime.Now;

            Console.WriteLine(date.ToString());

            Console.WriteLine(date.ToString("D",new CultureInfo("en-US")));
            Console.WriteLine(date.ToString("D", new CultureInfo("en-GB")));
            #endregion

        }

        public static void DateTime_manipulation2()
        {
            string dataString = "08/05/2025";
            CultureInfo culture = new CultureInfo("fr-FR");

            DateTime parsedate = DateTime.ParseExact(dataString, "dd/mm/yyyy", culture);
            Console.WriteLine(parsedate.ToString("yyyy-mm-dd"));
        }


    }
    


    public class Program
    {
        static void Main(string[] args)
        {
            String_functions obj = new String_functions();  
          obj.test();
            //Console.WriteLine("Hello, World!");
            StringBuilder sb = new StringBuilder();
            sb.Append("hello");
            sb.Append(" * ");
          Console.WriteLine(sb);
            //Formatting
            double price = 1234.567;
            Console.WriteLine(price.ToString("C"));
            Console.WriteLine(price.ToString("F3"));

            // DateTime data type
            //DateTime date =DateTime.Now; 
            //Console.WriteLine(date.ToString("dd-mm-yyyy"));
            Console.WriteLine(DateTime.UtcNow);
            String_functions.DateTime_manipulation();
            String_functions.DateTime_manipulation2();
        }
    }
}
