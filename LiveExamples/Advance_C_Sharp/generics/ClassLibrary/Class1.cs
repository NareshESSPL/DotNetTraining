namespace ClassLibrary
{
    public class Generics
    {

        public void Add<T>(T obj1, T obj2)
        {
            if(typeof(int)==obj1.GetType() && typeof(int) == obj2.GetType())
            {
                int i1 = Convert.ToInt32(obj1);
                int i2 = Convert.ToInt32(obj2);
                Console.WriteLine(i1+i2);
            }
            else if(typeof(string)== obj1.GetType() && typeof(string) == obj2.GetType()){
                string s1 = Convert.ToString(obj1);
                string s2 = Convert.ToString(obj2);
                Console.WriteLine(s1+s2);
            }
        }

    }

    public class Test
    {
        public void testing() { 
        Generics g = new Generics();
        int obj1 = 10;
        int obj2 = 10;
        
        g.Add<int>(obj1,obj2);
        }
    }
}
