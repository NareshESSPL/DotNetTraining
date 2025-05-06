using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    internal partial class ParticlassExample
    {
        public void MethodB()
        {

        }
    }

    /// <summary>
    /// MethodA() and MethodB() is written different files under same partial class
    /// </summary>
    public class TestPartialClass
    {
        public void Test()
        {
            ParticlassExample particlassExample = new ParticlassExample();

            particlassExample.MethodA();
            particlassExample.MethodB();
        }
    }
}
