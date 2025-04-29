using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublisherSubscriber
{
    public delegate void Notification(string message);

    public class Notifier
    {
        public Notification _notification;
        public Notifier(Notification notification)
        {
            _notification = notification;
        }

        public void UserSignUp(string username)
        {
            
            Console.WriteLine($"User '{username}' has signed up.");

            
            _notification?.Invoke($"Notification: Welcome {username}!");
        }
    }
    public class NotificationHandler
    {
        public void SendEmail(string message)
        {
            Console.WriteLine("Sending Email: " + message);
        }

        public void ShowPopup(string message)
        {
            Console.WriteLine("Showing Popup: " + message);
        }
    }
}
