using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace InvoiceApp.Models
{
    public class InvoiceDto
    {
        public int Id { get; set; }

        [Required]
        public string Number { get; set; } = "";

        [Required]
        public string Status { get; set; } = "";  // Paid or Pending

        public DateTime? IssueDate { get; set; }
        public DateTime? DueDate { get; set; }

        // Service Details
        [Required]
        public string Service { get; set; } = "";

        [Range(1, 999999, ErrorMessage = "Unit Price is not valid!")]
        public decimal UnitPrice { get; set; }

        [Range(1, 99)]
        public int Quantity { get; set; }

        // Client Details
        [Required(ErrorMessage = "Client Name is required")]
        public string ClientName { get; set; } = "";

        [Required, EmailAddress]
        public string Email { get; set; } = "";

        [Phone]
        public string Phone { get; set; } = "";

        public string Address { get; set; } = "";

        [Precision(16, 2)]
        public decimal UnitPlace { get; set; } = 1.0m;
    }
}
