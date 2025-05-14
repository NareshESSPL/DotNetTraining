namespace LinkedList
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello, World!");
            List<String> list = new List<string>();
            list.Add("a");
            list.Add("b");
            list.Add("c");
            list.Add("d");
            list.Remove("a");
            list.RemoveAt(0);

            List<String> list2 = new List<String>();
            list2 = new List<string> {"x", "y", "z"};

            list.AddRange(list2);

            foreach (var item in list) 
            { 
            Console.WriteLine(item);
            }
        }
    }
}
