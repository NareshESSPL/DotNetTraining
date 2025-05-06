using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdavncedCSharp
{
    public delegate void NotifyEventHandler(string message); // Define delegate

    public class Publisher
    {
        public event NotifyEventHandler Notify; // Declare event

        public void TriggerEvent(string message)
        {
            // Raise the event (if it has subscribers)
            Notify?.Invoke(message);
        }
    }

    public class Subscriber
    {
        public void OnNotify(string message)
        {
            Console.WriteLine($"Subscriber received: {message}");
        }
    }


    public class TestDelegate
    {
        public void Test()
        {
            Publisher publisher = new Publisher();
            Subscriber subscriber = new Subscriber();

            // Subscribe to the event
            publisher.Notify += subscriber.OnNotify;

            //you cannot invoke delegate outside of its class
            //but you can attach method outside of this class
            //publisher.Notify?.Invoke()

            // Trigger the event
            publisher.TriggerEvent("Hello, Events!");

            // Detach if needed
            publisher.Notify -= subscriber.OnNotify;
        }
    }


}
