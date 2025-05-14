namespace Dictionary
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            Dictionary<int, string> userDictionary = new Dictionary<int, string>();

            userDictionary.Add(1, "nik");
            userDictionary.Add(2, "ray");
            userDictionary.Add(3, "smith");

            userDictionary.Remove(1);

            Console.WriteLine("User with ID 2: " + userDictionary[2]);

            foreach (KeyValuePair<int, string> kvp in userDictionary)
            {
                Console.WriteLine("Key = " + kvp.Key + ", Value = " + kvp.Value);
            }

            Dictionary<int, char> obj1 = new Dictionary<int, char>();

            obj1.Add(1,'z');
            obj1.Add(2, 'b');
            obj1.Add('c', 'd');// here it is stored at key 99 bcz it take
                               // c as integer which have ascii value 99

            //displaying item
            foreach (KeyValuePair<int, char> item in obj1)
            {
                Console.WriteLine($"value:{item.Value} is present at key {item.Key}" );
            }
            bool x = userDictionary.ContainsKey(6);
            Console.WriteLine(" key 6 is present :"+x);

            bool Is_present = userDictionary.TryGetValue(1, out string name);
            Console.WriteLine("key 1 is present :"+ Is_present);
        }
    }

}
