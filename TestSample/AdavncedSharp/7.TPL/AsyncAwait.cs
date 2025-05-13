using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdavncedCSharp._7.TPL
{
    public class AsyncAwait
    {
        public async Task Test()
        {
            Console.WriteLine("Starting...");

            Task<string> task = GetDataAsync();
            Console.WriteLine("Doing other work while waiting...");

            string result = await task;
            Console.WriteLine($"Finished with result: {result}");
        }

        private async Task<string> GetDataAsync() 
        {
            await Task.Delay(2000); // Simulates waiting for data
            return "Hello, Async!";
        }
    }
}
