using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharp
{
    public delegate void Publisher();

    public class Notification
    {
        public Publisher publisher;
        public void RaiseNotification()
        {
            publisher();
        }
    }

    public class Client
    {
        public void Client1()
        {
            Console.WriteLine("Notification arrived - 1");
        }

        public void Client2()
        {
            Console.WriteLine("Notification arrived - 2");
        }

        public void Client3()
        {
            Console.WriteLine("Notification arrived - 3");
        }

        public void Subscribe()
        {
            Notification notification = new Notification();

            notification.publisher = new Publisher(Client1);
        }

    }

    public class Invoker
    {
        public void Invoke()
        {
            Client client = new Client();
            client.Subscribe();

            Notification notification = new Notification();
            notification.RaiseNotification();
        }
    }

}
