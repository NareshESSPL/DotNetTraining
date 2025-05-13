using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdavncedCSharp
{
    public class DelegateExample
    {
        public delegate void TestDelegate();

        public void ClientMethod1()
        {
            Console.WriteLine("Client Method 1 called");
        }

        private void ClientMethod2()
        {
            throw new NotImplementedException();
        }

        public void Test()
        {
            #region intialize delegate

            TestDelegate testDelegate = new TestDelegate(ClientMethod1);


            TestDelegate testDelegate2 = ClientMethod1;

            TestDelegate testDelegate3 = ClientMethod1;
            testDelegate3 += ClientMethod2;

            #endregion

            #region Invoke Delegate

            testDelegate3();

            testDelegate2.Invoke();            

            #endregion
        }
    }
}
