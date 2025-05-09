using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    public class DateTimeConversion
    {
        //CultureInfo.InvariantCulture → Ignores culture-specific formatting.

        //CultureInfo("en-US") → Uses MM/dd/yyyy format.

        //CultureInfo("fr-FR") → Uses dd/MM/yyyy format.

        //DateTimeStyles.None → Default parsing behavior.

        //DateTimeStyles.AssumeLocal → Assumes local time zone.
        public void Test()
        {
            string dateString = "08/05/2025"; // Day/Month/Year format
            CultureInfo culture = new CultureInfo("fr-FR"); // French culture (dd/MM/yyyy)

            DateTime parsedDate = DateTime.ParseExact(dateString, "dd/MM/yyyy", culture);
            Console.WriteLine(parsedDate.ToString("yyyy-MM-dd")); // Output: 2025-05-08

            string dateString2 = "08/05/2025";
            CultureInfo culture2 = new CultureInfo("fr-FR");

            if (DateTime.TryParseExact(dateString2, "dd/MM/yyyy", culture2, DateTimeStyles.None, out DateTime parsedDate2))
            {
                Console.WriteLine($"Parsed Date: {parsedDate2}");
            }
            else
            {
                Console.WriteLine("Invalid d
                    }
    }
}
