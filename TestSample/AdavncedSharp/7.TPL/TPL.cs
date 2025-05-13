using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPL
{
    public class TPL
    {
        public void TaskRun()
        {
            // Creating and starting two 
            // tasks to run concurrently
            Task task1 = Task.Run(() => PrintNumbers());
            Task task2 = Task.Run(() => PrintNumbers());

            // Waiting for both tasks to complete 
            // before exiting the program
            Task.WhenAll(task1, task2).Wait();
        }

        private void PrintNumbers()
        {
            // Printing numbers from 0 to 2 in each task
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(i);
            }
        }

        public void ParallelInvoke()
        {
            List<string> data = new List<string> { "Hello", "Geek", "How", "Are", "You" };

            // Execute multiple tasks in parallel
            Parallel.Invoke(
                () => Console.WriteLine($"Data => [{data[0]}] on thread:- {System.Threading.Thread.CurrentThread.ManagedThreadId}"),
                () => Console.WriteLine($"Data => [{data[1]}] on thread:- {System.Threading.Thread.CurrentThread.ManagedThreadId}"),
                () => Console.WriteLine($"Data => [{data[2]}] on thread:- {System.Threading.Thread.CurrentThread.ManagedThreadId}"),
                () => Console.WriteLine($"Data => [{data[3]}] on thread:- {System.Threading.Thread.CurrentThread.ManagedThreadId}"),
                () => Console.WriteLine($"Data => [{data[4]}] on thread:- {System.Threading.Thread.CurrentThread.ManagedThreadId}")
            );
        }

        public void ParalleForEach()
        {
            List<string> data = new List<string> { "Hello", "Geek", "How", "Are", "You" };

            // Create a CancellationTokenSource
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            // Create a task that uses the CancellationToken
            Task.Run(() =>
            {
                try
                {
                    Console.WriteLine("Task started.");
                    Parallel.ForEach(data, new ParallelOptions { CancellationToken = token }, item =>
                    {
                        // Check for cancellation
                        token.ThrowIfCancellationRequested();
                        Console.WriteLine($"Data [{item}] on thread: {Thread.CurrentThread.ManagedThreadId}");

                    });
                    Console.WriteLine("Task completed.");
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Task was canceled.");
                }
            }, token);


            Task.Delay(200).Wait();

            // Cancel the task
            cts.Cancel();

            // Dispose the CancellationTokenSource
            cts.Dispose();

            Console.WriteLine("Main method completed");
        }
    }
}
