using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace InvoiceApp.Models
{
    public class InvoiceDTO
    {
        [Required]
        public string Number { get; set; } = "";
        [Required]
        public string Status { get; set; } = "";

        public DateOnly? IssueDate { get; set; }
        public DateOnly? DueDate { get; set; }

        // Services
        [Required]
        public string Services { get; set; } = "";

        [Range(1,99999, ErrorMessage ="Unit Price inot Valid!!")]
        public decimal UnitPrice { get; set; }

        [Range(1,99)]
        public int Quantity { get; set; }


        // Client details
        [Required(ErrorMessage ="CLientName is required !! ")]
        public string ClientName { get; set; } = "";

        [Required,EmailAddress]
        public string Email { get; set; } = "";

        public string Address { get; set; } = "";

        [Phone]
        public string Phone { get; set; } = "";
    }
}
