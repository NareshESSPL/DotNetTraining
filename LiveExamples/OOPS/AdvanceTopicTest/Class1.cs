namespace AdvanceTopicTest
{
    public class StudentManager
    {
        public int StudentId{get;set;}

        public StudentManager() { }

        public bool IsPresent()
        {
            return true;
        }

    }

    public static class Utility
    {
        public static int WordCount(this String Name)
        {
            return Name.Split(" ").Length;
        }
        public static int WordCount2(this String Name,String word)
        {
            var x=Name.Split(" ");
            int count = 0;

            for(int i=0;i<x.Length;i++)
            {
                if (x[i] == word) count++;
            }
            return count;
        }
    }

    public class TestForCount
    {
        public void Test()
        {
            String Name = "I am a SoftWareEngineer";
            Console.WriteLine(Name.WordCount());
            Console.WriteLine(Name.WordCount2("a"));
        }
    }
}
