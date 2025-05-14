using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public  class PredicateExample
    {
        //public delegate bool Predicate<T1,T2>(T2 obj2,T3 obj3);
        public void Test()
        {
            Predicate<string> predicate
                 = (string input2) => true;
        }

        public void PredicateAsInput<T1 ,T2>(Predicate)
        {
            Predicate< >
        }



    }
}
