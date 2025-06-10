namespace testing
{
    public delegate void functionaldelegate(int SurveyTypeID, string SurveyTypeName, string ModifiedBy, string ModifiedDate);
    //public delegate void functionaldelegate(Survey s);


    public class Testdelegate
    {
        public void AddSurvey()
        {
            Console.WriteLine("Add survey method");
        }
        public void UpdateSurvey()
        {
            Console.WriteLine("Update survey method");
        }
        public void DeleteSurvey()
        {
            Console.WriteLine(" Delete survey method");
        }
        public static void main(String[] args)
        {
            functionaldelegate fd = new functionaldelegate(AddSurvey;
            fd += UpdateSurvey;
            fd += Deletesurvey;
        }
    }
