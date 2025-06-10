 
//Create an abstract class (SurveyBase)
//Create an abstract class (SurveyBase)

 
namespace secondquestion
{
    public abstract class SurveyBase
    {
        public int SurveyID { get; set; }
        public int SurveyTypeID { get; set; }
        public string SurveyTypeName { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }

    public class Class1 : SurveyBase
    {
        public Class1()
        {
            
            SurveyID = 1;  
            SurveyTypeID = 100; 
            SurveyTypeName = "Default Survey Type"; 
            ModifiedBy = "System";  
            ModifiedDate = DateTime.Now; 
        }
        
         
    }
}
