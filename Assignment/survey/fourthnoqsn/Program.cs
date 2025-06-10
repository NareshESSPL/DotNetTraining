namespace fourthnoqsn
{
    
     
    internal abstract class AbstractBase
    {
        protected AbstractBase() {
            Console.WriteLine("AbstractBase constructor called.");
        }
         
        public abstract void ExecuteSurvey();
    }

  
    internal interface ISurvey
    {
       

        void StartSurvey();

    }

     
    internal class SurveyManager : AbstractBase, ISurvey
    {
        public override void ExecuteSurvey()
        {

            Console.WriteLine("Executing survey...");
        }

        public void StartSurvey()
        {
            Console.WriteLine("Starting survey...");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
             
            SurveyManager surveyManager = new SurveyManager();
            surveyManager.StartSurvey();
            surveyManager.ExecuteSurvey();
        }
    }
}
