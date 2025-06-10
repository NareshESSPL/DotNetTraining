using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataLayer; 
using DTO;


namespace Assessment.Models
{
    public class SurveyViewModel
    {
        public int SurveyID { get; set; }

        [Display(Name = "Survey Type")]
        [Required(ErrorMessage = "Survey Type is required.")]
        public int SurveyTypeID { get; set; }

        [Required(ErrorMessage = "Survey Name is required.")]
        [StringLength(100, ErrorMessage = "Survey Name cannot exceed 100 characters.")]
        [Display(Name = "Survey Name")]
        public string SurveyName { get; set; } = string.Empty;

        // Properties for tracking who modified and when (often handled by backend/filters)
        public string ModifiedBy { get; set; } = "WebAppUser"; // Default or retrieve from authentication
        public System.DateTime ModifiedDate { get; set; } = System.DateTime.Now; // Default or set by backend

        // For the dropdown list of Survey Types in the View
        public IEnumerable<SelectListItem> SurveyTypes { get; set; }
    }
}

