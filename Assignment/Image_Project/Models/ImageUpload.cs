using System.ComponentModel.DataAnnotations.Schema;

namespace Image_Project.Models
{
    [Table("ImageUpload")]
    public class ImageUpload
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] ImageData { get; set; }
    }
}
