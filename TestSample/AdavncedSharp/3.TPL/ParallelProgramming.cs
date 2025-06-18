using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdavncedCSharp
{
    public class ParallelProgramming
    {
        public void TestParallelForeach()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();            
            cancellationTokenSource.CancelAfter(5000);

            //Limiting the maximum degree of parallelism to 3
            var options1 = new ParallelOptions()
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount - 1,
                CancellationToken = cancellationTokenSource.Token
            };

            var strings = new List<string> { "s1", "s2", "s3" };
            Parallel.ForEach(strings, options1, s =>
            {
                Thread.Sleep(1000);
                Console.WriteLine(s);
            });


            //Limiting the maximum degree of parallelism to 3
            var options2 = new ParallelOptions()
            {
                MaxDegreeOfParallelism = 3
            };

            //A maximum of three threads are going to execute the code parallelly
            Parallel.For(1, 11, options2, i =>
            {
                Thread.Sleep(500);
                Console.WriteLine($"Value of i = {i}, Thread = {Thread.CurrentThread.ManagedThreadId}");
            });
        }

        public async void Test()
        {
            List<string> strings = new List<string> { "s1", "s2", "s3" };
            List<Task> tasklist = new List<Task>();
            foreach (var s in strings)
            {
                tasklist.Add(Task.Run(() => Console.WriteLine(s)));
            }

            await Task.WhenAll(tasklist);
        }


        private async void SomeMethod()
        {
            int count = 10;
            Console.WriteLine("SomeMethod Method Started");
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.CancelAfter(5000);
            try
            {
                await LongRunningTask(count, cancellationTokenSource.Token);
            }
            catch (TaskCanceledException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            Console.WriteLine("\nSomeMethod Method Completed");
        }


        public async Task LongRunningTask(int count, CancellationToken token)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("\nLongRunningTask Started");
            for (int i = 1; i <= count; i++)
            {
                await Task.Delay(1000);
                Console.WriteLine("LongRunningTask Processing....");
                if (token.IsCancellationRequested)
                {
                    throw new TaskCanceledException();
                }
            }
            stopwatch.Stop();
            Console.WriteLine($"LongRunningTask Took {stopwatch.ElapsedMilliseconds / 1000.0} Seconds for Processing");
        }
    }
}
