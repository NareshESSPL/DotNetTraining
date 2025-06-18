using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApp.Models
{
    public class Invoice
    {
    
        public int Id { get; set; }
        public string Number { get; set; } = "";
        [Required]
        public string Status { get; set; } = "";

        public DateOnly? IssueDate { get; set; }
        public DateOnly? DueDate  { get; set; }

        // Services
        public string Services { get; set; } = "";

        [Precision(18, 2)]
        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }


        // Client details
        public string ClientName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Address { get; set; } = "";
        public string Phone { get; set; } = "";
    }
}
