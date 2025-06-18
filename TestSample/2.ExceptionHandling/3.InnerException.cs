using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    public class InnerException
    {
        public void TestInnerException(int input)
        {
            try
            {
                try
                {
                    // Simulate an inner exception
                    int result = input / 0; // Causes DivideByZeroException
                }
                catch (DivideByZeroException innerEx)
                {
                    // Wrap inner exception in a new exception
                    throw new InvalidOperationException("A calculation error occurred.", innerEx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Outer Exception: {ex.Message}");

                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
            }
        }
    }
}
