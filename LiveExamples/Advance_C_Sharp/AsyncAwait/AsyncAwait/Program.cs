namespace AsyncAwait
{
    public  class Program
    {
        private static async Task<string> DoProcess()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine(i);
                }
            });

            return "Processing Complete";
        }


        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            var strings = new List<string> { "eat","code","sleep"};
            strings.ForEach(x => Console.WriteLine(x));

            Console.WriteLine("\n"); 

            Parallel.ForEach(strings ,x => Console.WriteLine(x));
            Console.WriteLine("end");
        }
    }
}
