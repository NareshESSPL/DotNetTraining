using System.Text;

//Culture is part of this namespace
using System.Globalization;

namespace DataTypes
{
    public class StringManipulation
    {
        public void Concatenation()
        {
            //+
            string firstName = "John";
            string lastName = "Doe";
            string fullName = firstName + " " + lastName;
            Console.WriteLine(fullName); // Output: John Doe

            //concat
            string fullName2 = String.Concat("John", " ", "Doe");
            Console.WriteLine(fullName2);

            //Join
            string[] words = { "Hello", "World", "!" };
            string sentence = String.Join(" ", words);
            Console.WriteLine(sentence); // Output: Hello World !

            //Stringbuilder
            //used for large string concatination
            StringBuilder sb = new StringBuilder();
            sb.Append("Hello");
            sb.Append(" ");
            sb.Append("World");
            Console.WriteLine(sb.ToString()); // Output: Hello World
        }

        public void Formatting()
        {
            //Format
            string name = "Alice";
            int age = 25;
            string formattedString = String.Format("Name: {0}, Age: {1}", name, age);
            Console.WriteLine(formattedString);

            //Interpolation
            string formattedString2 = $"Name: {name}, Age: {age}";
            Console.WriteLine(formattedString2);

            //ToString()
            double price = 1234.567;
            Console.WriteLine(price.ToString("C")); // Output: $1,234.57 (Currency format)
            Console.WriteLine(price.ToString("F2")); // Output: 1234.57 (Fixed-point format)
        }

        public void Conversion()
        {
            //Format
            int number = 100;
            string strNumber = number.ToString();
            Console.WriteLine(strNumber); // Output: "100"

            //In C#, Convert.ToString(null) returns an empty string ("") 
            //    instead of null. This is useful when you want to avoid 
            //    NullReferenceException while converting objects to strings.

            //Convert.ToString(null)  Returns ""(empty string)
            //Convert.ToString(null as object)    Returns ""(empty string)
            //Convert.ToString((string)null)  Returns null
            //null.ToString() Throws NullReferenceException
            int? number4 = null;
            string strNumber2 = Convert.ToString(number4);


            //Interpolation
            DateTime date = DateTime.Now;
            Console.WriteLine(date.ToString("yyyy-MM-dd")); // Output: 2025-05-08
        }

        public void CultureBasedFormatting()
        {
            #region DateTime

            DateTime date = DateTime.Now;

            // Default culture
            Console.WriteLine(date.ToString());

            // US format (MM/dd/yyyy)
            Console.WriteLine(date.ToString("D", new CultureInfo("en-US"))); // Output: Monday, May 8, 2025

            // German format (dd.MM.yyyy)
            Console.WriteLine(date.ToString("D", new CultureInfo("de-DE"))); // Output: Montag, 8. Mai 2025

            #endregion

            #region Currency

            decimal price = 1234.56m;

            // US Dollar format
            Console.WriteLine(price.ToString("C", new CultureInfo("en-US"))); // Output: $1,234.56

            // Euro format (Germany)
            Console.WriteLine(price.ToString("C", new CultureInfo("de-DE"))); // Output: 1.234,56 €

            #endregion

            //Invarinat Culture
            //Uses a culture-independent format (useful for machine-readable formats).
            Console.WriteLine(date.ToString("D", CultureInfo.InvariantCulture));

            //Current Culture
            //Uses the system's default culture.
            Console.WriteLine(date.ToString("D", CultureInfo.CurrentCulture));

        }
    }
}

