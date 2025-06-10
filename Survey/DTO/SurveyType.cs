using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class  SurveyType
    {
        [Key]
        public int SurveyTypeID { get;set; }
        [Required]
        public string SurveyTypeName { get;set;}
        [Required]
        public string ModifiedBy { get;set;}
        [Required]
        public DateTime ModifiedDate { get;set;}


    }
}
