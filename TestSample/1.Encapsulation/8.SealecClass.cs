using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    /// <summary>
    /// Selaed class cnnot be inherited
    /// The logic which should not be modified or changed or overwritten
    /// can be kept in Sealed class
    /// </summary>
    public sealed class ProfitCalcultor
    {
        public decimal Calculate()
        {
            var netProfit = 18M;

            var operatingCost = 10M;

            return netProfit - operatingCost;
        }
    }

    public class TestSealed 
    {
        public void Test()
        {
            ProfitCalcultor profitCalcultor = new ProfitCalcultor();

            var data = profitCalcultor.Calculate();

            Console.WriteLine(data);
        }
    }
}
