using System.ComponentModel.DataAnnotations;

namespace help
{
    public class hello
    {
        [Required]
        public String Name { get; set; }
        [Required]
        public int RollNo { get; set; }
        [Range(5,25)]
        public  int Age { get; set; }
        [Required]
        public String Address { get; set; }



    }
}
