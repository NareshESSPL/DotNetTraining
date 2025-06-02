using Microsoft.AspNetCore.Http;

namespace support
{
    public class help
    {
        public int PatientId { get; set; }
        public String PatientName { get; set; }
        public int Age {  get; set; }
        public String Address { get; set; }
        public IFormFile Document { get; set; }
        public string DocumentPath { get; set; }



    }
}
