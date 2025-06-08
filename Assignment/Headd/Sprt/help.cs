using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Http;

namespace Sprt
{
    public class help
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int age { get; set; }
        
        public IFormFile Document { get; set; }
        public String DocumentPath { get; set; }


    }
}
