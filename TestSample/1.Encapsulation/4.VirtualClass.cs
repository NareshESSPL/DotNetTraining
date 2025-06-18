using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    public class BaseClass
    {
        public void TestHideMethod()
        {

        }

        public virtual void TestVirtualMethod1()
        {

        }

        public virtual void TestVirtualMethod2()
        {

        }
    }

    public class DerivedClass : BaseClass
    {
        public void TestHideMethod()
        {

        }

        public override void TestVirtualMethod2()
        {

        }
    }
}
