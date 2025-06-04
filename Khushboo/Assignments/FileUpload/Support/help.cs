
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Support
{
    public class help
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Branch { get; set; }

        [NotMapped]
        public IFormFile Document { get; set; }

        public string DocumentPath { get; set; }
    }
}
