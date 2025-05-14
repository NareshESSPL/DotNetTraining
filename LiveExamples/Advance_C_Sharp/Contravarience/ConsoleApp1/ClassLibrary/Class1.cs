namespace ClassLibrary
{
    public class Contravariance
    {
        public class Parent
        {

        }
        public class Child : Parent 
        {
        
        }

        public class Test
        {
            public void Testing(Parent par)
            {
                Console.WriteLine(par.GetType());
            }
            public void Test2()
            {
                Testing(new Child());
            }
            public void Test3(Child ch)
            {
                Console.WriteLine("bro");
            }
            public void Test4()
            {
                Test3(new Parent());
            }
        }
    }
}
