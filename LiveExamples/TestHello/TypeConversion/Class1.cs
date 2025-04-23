using System.Globalization;

namespace TypeConversion
{
    public class TyepCasting
    {

        public void Test()
        {
            /*type casting*/

            object input = "111";

            int output1 = (int)input;

            int input2 = 1;
            decimal output2 = (decimal)input2;

            /*end type casting*/

            /*parse*/
            string input4 = "1111";

            //will break if the data is non-nuymeric
            int output5 = int.Parse(input4);
             
            int.TryParse(input4, out int output6);
            /*end parse*/

            /*Convert*/

            CultureInfo frenchCulture = CultureInfo.GetCultureInfo("fr-FR");
            string formattedDateFrench = Convert.ToString(DateTime.Now, frenchCulture);
            Console.WriteLine(formattedDateFrench);

            string outDate = DateTime.Now.ToString("ddMMyyyy");

            /*End Convert*/

            object input9 = "1111";
            string? output9 = input9 as string;

            object input10 = 1111;
            int? output10 = input10 as int?;

            // Value type variable
            int n = 357;

            // Boxing
            object box = n;

            // Unboxing
            int unbox = (int)box;

        }
    }
}
