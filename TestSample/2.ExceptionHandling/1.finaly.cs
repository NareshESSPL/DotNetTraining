using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    public class Finally
    {

        /// <summary>
        /// Example of finally
        /// </summary>
        public void TestFinally()
        {
            try
            {

                int[] ints = { 1, 2, 3 };

                for (int i = 0; i < 9; i++)
                    Console.WriteLine(ints[i]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine("Finally called");
            }
        }

        /// <summary>
        /// Here thow is called in catch, hence the control flow will exit
        /// and finally will not be called
        /// </summary>
        public void TestFinallyWithThrow()
        {
            try
            {

                int[] ints = { 1, 2, 3 };

                for (int i = 0; i < 9; i++)
                    Console.WriteLine(ints[i]);
            }
            catch (Exception ex)
            {
                throw;
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine("Finally will not be called");
            }
        }
    }
}
