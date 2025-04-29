using CollegeResultNotification;
using PublisherSubscriber;

namespace PublisherSubscriberDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TestLogger logger = new TestLogger();
            //logger.Test();

            TestCollegeResult testCollegeResult = new TestCollegeResult();
            testCollegeResult.Test();
        }
    }
}
