using InvoiceApp.Models;
using InvoiceApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InvoiceApp.Pages.Invoices
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public EditModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public InvoiceDto InvoiceDto { get; set; }

        public Invoice Invoice { get; set; }

        public string successMessage = "";

        public IActionResult OnGet([FromQuery] int? number)
        {
            if (number == null)
            {
                return RedirectToPage("/Invoices/Index");
            }
            string numberString = number.ToString();

            Invoice = context.Invoices.FirstOrDefault(i => i.Number == numberString);

            if (Invoice == null)
            {
                return NotFound();
            }

            // Map values from Invoice to InvoiceDto
            InvoiceDto = new InvoiceDto
            {
                Number = Invoice.Number,
                Status = Invoice.Status,
                IssueDate = Invoice.IssueDate,
                DueDate = Invoice.DueDate,
                ClientName = Invoice.ClientName,
                Email = Invoice.Email,
                Phone = Invoice.Phone,
                Address = Invoice.Address,
                Service = Invoice.Service,
                Quantity = Invoice.Quantity,
                UnitPrice = Invoice.UnitPrice,
                UnitPlace = Invoice.UnitPlace
            };

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var invoice = context.Invoices.FirstOrDefault(i => i.Number == InvoiceDto.Number);

            if (invoice == null)
            {
                return NotFound();
            }

            // Update fields
            invoice.Status = InvoiceDto.Status;
            invoice.IssueDate = InvoiceDto.IssueDate;
            invoice.DueDate = InvoiceDto.DueDate;
            invoice.ClientName = InvoiceDto.ClientName;
            invoice.Email = InvoiceDto.Email;
            invoice.Phone = InvoiceDto.Phone;
            invoice.Address = InvoiceDto.Address;
            invoice.Service = InvoiceDto.Service;
            invoice.Quantity = InvoiceDto.Quantity;
            invoice.UnitPrice = InvoiceDto.UnitPrice;
            invoice.UnitPlace = InvoiceDto.UnitPlace;

            context.SaveChanges();

            successMessage = "Invoice updated successfully!";

            return RedirectToPage("/Invoices/Index");
        }
    }
}
