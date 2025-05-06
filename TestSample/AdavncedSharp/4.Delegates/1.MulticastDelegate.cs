using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdavncedCSharp
{
    /*
     * A multicast delegate in programming, particularly in languages like C#, 
     * is a type of delegate that can hold references to multiple methods. When the delegate is invoked, it calls all the methods it references sequentially. It's like a list of methods bound together in one delegate.

        Key Features:
        Multiple Method Invocation: A multicast delegate can call multiple methods 
                in the order they were added. For instance, you might use it to 
                handle events where multiple actions need to be performed.

        Combining Methods: You can use the += operator to add methods to a multicast delegate 
                           and the -= operator to remove them.

        Return Values: If the methods have a return value, only the result from the 
                       last invoked method is returned. However, all methods in the 
                       delegate are executed unless explicitly stopped.
     
    */
    public class MulticastDelegateExample
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

        private void ClientMethod3()
        {
            throw new NotImplementedException();
        }

        public void Test()
        {
            #region intialize delegate

            TestDelegate testDelegate3 = ClientMethod1;
            testDelegate3 += ClientMethod2;
            testDelegate3 += ClientMethod3;

            #endregion

            #region remove method from delegate

            testDelegate3 -= ClientMethod3;

            #endregion

            #region Invoke Delegate

            testDelegate3();

            #endregion
        }
    }
}
