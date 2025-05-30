using System.ComponentModel.DataAnnotations;

namespace Help
{
    public class hey
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string OrderId { get; set; }

    }
}
