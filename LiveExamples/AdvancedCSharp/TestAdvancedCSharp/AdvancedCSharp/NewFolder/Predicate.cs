using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharp.NewFolder
{
    //public delegate bool Predicate<T2, T3>(T2 obj2, T3 obj3);
    public class PredicateExample
    {
        public void Test()
        {
            Predicate<string> predicate 
                = (string input2) => true;
            
        }
    }
}
