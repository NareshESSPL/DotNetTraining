using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    public class ConstVsReadOnly
    {
        // Compile-time constant.Cannot change after this
        public const double Pi = 3.14159;

        // Runtime value
        public readonly string CreatedAt = DateTime.Now.ToString();
        public readonly int MaxLimit;

        public ConstVsReadOnly(int limit)
        {
            // Assignable in constructor, cannot modify after this
            MaxLimit = limit;
        }


        public void TestConstVsReadOnly()
        {
            Console.WriteLine(Pi); // Outputs: 3.14159
        }
    }
}
