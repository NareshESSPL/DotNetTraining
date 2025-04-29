using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsConcept
{
    public class TestExec
    {
        public void Exce()
        {
            for (int i = 0; i <= 5; i++)
            {
                try
                {
                    if (i == 3)
                    {

                        throw new Exception("Exception at iteration: " + i);
                        
                    }
                    Console.WriteLine($"Iteration {i} completed successfully.");
                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine($"Handled Exception: {ex.Message}");
                }
            }
            Console.WriteLine("All iterations completed.");
        }
    }
}
