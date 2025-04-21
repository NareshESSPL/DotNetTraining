using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    public class TestClass
    {
        public string FullName { get; set; }
        public string AppName { get; } = "Data";

        //can be set during declaration and cannot be changed after that
        public const string Version = "1.0.0";

        //can be set inside a constructor but not in any other places
        public readonly bool ReadyForRelease;

        public TestClass()
        {
            ReadyForRelease = false;
        }

        public TestClass(bool readyForRelease)
        {
            ReadyForRelease = readyForRelease;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Test()
        {
            int x = 1;
            x = x + 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string TestStringReturn()
        {
            return "test data";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string TestPrivate()
        {
            string x = "test";

            return x;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal string TestInternal()
        {
            string x = "test";

            return x;
        }
    }

    public class ChildClass : TestClass
    {
        public string ChildName { get; set; }

        public ChildClass()
        {
            ChildClassName = "ChildClass";
        }

        public ChildClass(string childClassName)
        {
            if (childClassName != "")
                ChildName = "ChildClass";
            else
                ChildName = "No ChildClass";

        }

        public ChildClass(bool readyForRelease) : base(readyForRelease)
        {

        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~ChildClass()
        {
            Console.WriteLine("Logger object destroyed.");
        }

    }


}
