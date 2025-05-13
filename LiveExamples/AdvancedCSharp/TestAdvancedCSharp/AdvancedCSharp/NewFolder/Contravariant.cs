using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharp.NewFolder
{
    public interface IContravariant<in T>
    {
        public void Display(T input);
    }

    public class Contravariant<T> : IContravariant<T>
    {
        public void Display(T input)
        {
            Console.WriteLine(default(T));
        }
    }

    public class BaseClass
    {

    }

    public class ChildClass : BaseClass
    {

    }

    public class TestContra
    {
        public void Test()
        {
            IContravariant<ChildClass> contravariant = new Contravariant<BaseClass>();

            contravariant.Display(new ChildClass());
        }
    }
}
