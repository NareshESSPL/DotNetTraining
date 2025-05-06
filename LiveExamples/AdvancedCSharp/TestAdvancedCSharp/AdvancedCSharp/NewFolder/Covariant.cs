using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharp.NewFolder
{
    public interface ICovariant<out T>
    {
        public T GetVal();
    }

    public class Covariant<T> : ICovariant<T>
    {
        public T GetVal()
        {
            return default(T);
        }
    }


    public class TestCo
    {
        public void Test()
        {
            ICovariant<BaseClass> covariant = new Covariant<ChildClass>();

            var d = covariant.GetVal();
        }
    }
}
