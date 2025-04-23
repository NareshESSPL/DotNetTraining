using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    public class OverridingBase
    {
        public string TaskName { get; set; }
        public void Test()
        {
            Console.WriteLine("Calling Parent");
        }

        public void DoTask()
        {
            Console.WriteLine("Calling Parent.DoTask");
        }
    }

    public class OverridingChild : OverridingBase
    {
        public new void Test()
        {
            Console.WriteLine("Calling Child");
        }
        public void Testing()
        {
            //base class methid
            base.Test();
            this.Test();

        }
    }

    public class TestOverride
    {
        public void Test()
        {
            OverridingChild child = new OverridingChild();
            
            child.DoTask();
            child.TaskName = "";
            child.Test();
        }

    }
}
