namespace AdvanceCSharp

{
    public class StudentManager
    {
        public string StudentName {  get; set; }

        public string Paragraph { get; set; }

        public int StudentId { get; set; }  
        public StudentManager() { }

        public bool IsPresent()
        {
            return true;
        }
    }

    public static class Test
    {
        public static int CountWord(this string sentence)
        {
            string[] words = sentence.Split(' ');
            return words.Length;
        }

        public static int CountReapeatWord(this string sentence,string Word )
        {
            string[] words = sentence.Split(' ');
            int count = 0;
            foreach (string word in words)
            {
                if (word.Equals(Word, StringComparison.OrdinalIgnoreCase)) // Case-insensitive comparison
                {
                    count++;
                }
            }
            return count;
        }
    }
    public class Calling() { 
        public void test()
        {
            string sentence = "Hello how are you.";
            int Wordcount = sentence.CountWord();

            Console.WriteLine("Number of Words is :" + Wordcount);


        }
    }

}
