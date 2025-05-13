using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdavncedCSharp
{
    public class GenericMethodExample
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        public void ExampleMethod<T>(T item) where T : new()
        {
            T newItem = new T(); // This is possible due to the 'new()' constraint.
            Console.WriteLine(newItem.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        public void ExampleMethod2<T>(T item) where T : class
        {
            Console.WriteLine(item.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        public void ExampleMethod3<T>(T item) where T : struct
        {
            Console.WriteLine(item.ToString());
        }

        /// <summary>
        /// Multiple constraint
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        public void ExampleMethod4<T>(T item) where T : struct, ITestGenericMethod1, ITestGenericMethod2
        {
            Console.WriteLine(item.ToString());
        }

        /// <summary>
        /// Multiple constraint
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        public void ExampleMethod5<T>(T item) where T : BaseClass, new()
        {
            Console.WriteLine(item.ToString());
        }

    }

    public interface ITestGenericMethod1
    {

    }

    public interface ITestGenericMethod2
    {

    }
    public class BaseClass
    {
        public BaseClass() { }
    }
}
