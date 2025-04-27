using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    public class MethodExample
    {
        #region Method with access specifier

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

        /// <summary>
        /// New Sty;e
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns>FullName</returns>
        public string GetFullName(string firstName, string lastName) => $"{firstName} {lastName}";

        #endregion


        #region overloading

        public int Add(int x, int y)
        {

            return x + y;
        }

        public int Add(int x, int y, int z)
        {
            return x + y + z;
        }

        #endregion

    }
}
