namespace IImage_Uploadd.ViewModel
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly DOB { get; set; }

        public string Email { get; set; }
        public IFormFile? ImagePath { get; set; }
    
    }
}
