using System.ComponentModel.DataAnnotations;

namespace Survey_System.DTO
{
    public class SurveyDTO
    {
        [Required]
        public int SurveyTypeID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "SurveyTypeName cannot exceed 100 characters.")]
        public string SurveyTypeName { get; set; } = string.Empty;

        [Required]
        [StringLength(100, ErrorMessage = "ModifiedBy cannot exceed 100 characters.")]
        public string ModifiedBy { get; set; } = string.Empty;

        [Required]
        public string ModifiedDate { get; set; } = string.Empty;
    }
}