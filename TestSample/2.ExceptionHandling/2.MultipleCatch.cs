using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    public class MultipleCatch
    {
        /// <summary>
        /// We can have multiple catch with different Exception Type
        /// the catch block matching Exception Type will be called
        /// </summary>
        public void TestMultipleCatch()
        {
            try
            {
                int[] numbers = { 10, 20, 30 };
                Console.WriteLine(numbers[5]); // Causes IndexOutOfRangeException
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Cannot divide by zero: {ex.Message}");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Index out of bounds: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General exception caught: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Execution completed.");
            }
        }
    }
}
