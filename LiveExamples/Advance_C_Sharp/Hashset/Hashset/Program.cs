namespace Hashset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> fridge = new HashSet<string>();

            fridge.Add("milk");
            fridge.Add("Water");
            Console.WriteLine( fridge.Add("milk"));// we cant take two duplicates

            foreach (string thing in fridge)
            {
                Console.WriteLine(thing);   
            }

            if (fridge.Contains("milk"))
            {
                Console.WriteLine("milk is in the set.");
            }

            Console.WriteLine("Juice is there in fridge :"+ Convert.ToString(fridge.Contains("Juice")));
        }
    }
}
