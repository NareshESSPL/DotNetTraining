using Microsoft.EntityFrameworkCore;

namespace InvoiceApp.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Status { get; set; }
        public string ClientName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? DueDate { get; set; }

        public string Service { get; set; } = " ";
        [Precision(16, 2)]
        public decimal UnitPlace { get; set; } = 1.0m;

        public string? Email { get; set; } = " ";
        public string Phone { get; set; } = " ";
        public string Address {  get; set; } = " ";

    }
}
