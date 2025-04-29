using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsConcept
{
    public class OverridingBase()
    {
        public void Test()
        {
            Console.WriteLine("CALLING parent");
        }
        public void doTask()
        {
            Console.WriteLine("calling from base.dotask");
        }
    }
    public class OverridingChild : OverridingBase
    {
        public new void Test()
        {
            Console.WriteLine("Calling child");
        }
        public void Testing()
        {
            base.Test();
            this.Test();
        }
    }

    public class TestOverride
    {
        public void Test()
        {
            OverridingChild child = new OverridingChild();
            child.Test();
            child.Testing();
            OverridingBase bsc = new OverridingChild();
            bsc.doTask();
        }
    }
}
