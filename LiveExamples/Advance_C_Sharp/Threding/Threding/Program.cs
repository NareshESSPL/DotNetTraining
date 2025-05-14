using System.Collections.Concurrent;

namespace Threding
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            var strings = new ConcurrentBag<string> { "WakeUp", "Eat", "Work" ,"Sleeep"};

            // Using List.ForEach
            // strings.ForEach(s => Console.WriteLine(s));

            CancellationTokenSource cts = new CancellationTokenSource();
            ParallelOptions options = new ParallelOptions
            {
                MaxDegreeOfParallelism = 2,
                CancellationToken = cts.Token
            };

            Task.Factory.StartNew(() =>
            {
                if (Console.ReadKey().KeyChar == 'c')
                {
                    cts.Cancel();
                }
                Console.WriteLine("Press any key to exit");
            });

            try
            {
                var arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };    
                Parallel.ForEach(arr, options, (str) =>
                {
                    strings.Add("Bol Bhidu");
                   // strings.Remove("Bol Bhid u");
                    Console.WriteLine(str);
                });
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine("Operation was canceled: " + e.Message);
            }
            finally
            {
                cts.Dispose();
            }

            // Using Parallel.ForEach
            Parallel.ForEach(strings, s => Console.WriteLine(s));
        }
    }

}
