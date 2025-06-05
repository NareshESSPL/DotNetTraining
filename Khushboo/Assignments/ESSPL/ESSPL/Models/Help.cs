using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESSPL.Models
{
    public class Help
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Field is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Field is required.")]
        public string Department { get; set; }

        // stores file name saved on server

        public string DocumentPath { get; set; }

        // not mapped, for upload binding
        [NotMapped]
        public IFormFile Document { get; set; }
    }
}

