using PublisherSubscriber;

namespace AdvnceTopic
{
    public static class Utility
    {
        public static int WordCount(this string Name)
        {
            return Name.Split(" ").Length;
        }
        
    }
    public class Test
    {
        public static void Main(string[] args)
        {
            //TestLogger testLogger = new TestLogger();
            //testLogger.Test();
            NotificationHandler handler = new NotificationHandler();

            // You can attach multiple methods using delegate chaining
            Notification notify = handler.SendEmail;
            notify += handler.ShowPopup;

            Notifier notifier = new Notifier(notify);

            notifier.UserSignUp("john_doe");

        }
    }
}
