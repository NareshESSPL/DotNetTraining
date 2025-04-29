namespace CollegeResultNotification
{
    public delegate void ResultNotificationHandler(string message);

    public class CollegeResult
    {

        ResultNotificationHandler handler;

        public CollegeResult(ResultNotificationHandler handler)
        {
            this.handler = handler;
        }

        public void doProcess()
        {
            String[] subject = { "sub:1", "sub:2" };

            foreach(String s in subject)
            {
                handler(s + " result declared");
            }
        }

    }

    public class TestCollegeResult
    {

        public void Test()
        {
            ResultNotificationHandler result=new ResultNotificationHandler(notify);
            CollegeResult result2=new CollegeResult(result);
            result2.doProcess();
        }
        public void notify(String Message)
        {
            Console.WriteLine(Message);
        }
    }





}
