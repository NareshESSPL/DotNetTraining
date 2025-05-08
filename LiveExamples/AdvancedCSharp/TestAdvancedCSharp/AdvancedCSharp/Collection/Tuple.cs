using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharp.Collection
{
    public class TestTuple
    {
        public (string, int, string) Test()
        {
            return ("", 1, "");
        }

        public Tuple<int, string, int> Test2()
        {
            var output = new Tuple<int, string, int>(1, "Naresh", 2);

            return output;
        }
    }
}
