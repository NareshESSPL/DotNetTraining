namespace onenoo
{
     
    internal abstract class AbstractBase
    {
        public abstract void PerformSurvey();
    }

     
 
    internal interface ISurvey
    {
        void AddSurvey();
        void UpdateSurvey();
        void DeleteSurvey();
        void StartSurvey();
    }

  
internal class SurveyManager : AbstractBase, ISurvey
    {
        public override void PerformSurvey()
        {


            Console.WriteLine("perform  survey");
        }

        public void StartSurvey()
        {

            Console.WriteLine("stating survey");
        }

         
        public void AddSurvey()
        {
            
            Console.WriteLine("adding  survey");
        }

        public void UpdateSurvey()
        {

            Console.WriteLine("updating servey");
        }

        public void DeleteSurvey()
        {

            Console.WriteLine("delete survey");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            SurveyManager surveyManager = new SurveyManager();
            surveyManager.StartSurvey();
            surveyManager.PerformSurvey();

           
            surveyManager.AddSurvey();
            surveyManager.UpdateSurvey();
            surveyManager.DeleteSurvey();
        }
    }
}
