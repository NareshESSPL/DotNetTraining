namespace Publisher_Subscriber_Event
{
    public delegate void NotifyEventHandler(string message);//delegate declaration

    public class Publisher
    {
        public event NotifyEventHandler Notify;//event declaration 
            public void TriggerEvent(string message)
            {
                Notify?.Invoke(message);//raise event if has subsrcibed
            }


           
    }
    public class Subscriber
    {
        public void OnNotify(string message)
        {
            Console.WriteLine($"Subscriber revealed:{message}");
        }
    }

    public class Test
    {
        public void testing()
        {
            Publisher publisher = new Publisher();
            publisher.TriggerEvent("hello");
            Subscriber subscriber = new Subscriber();
            publisher.Notify += subscriber.OnNotify;
            //publisher.Notify += subscriber.OnNotify;
            //publisher.Notify -= subscriber.OnNotify;

           // publisher.Notify.Invoke("hello");//can't possible
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            ////Console.WriteLine("Hello, World!");
            //Publisher publisher = new Publisher();
            //publisher.TriggerEvent("hello");
            //Subscriber subscriber = new Subscriber();
            //publisher.Notify += subscriber.OnNotify;

            //Test obj = new Test();
            //obj.testing();
            Publisher p = new Publisher();
            //p.Notify.Invoke("hello");
        }
    }
}
