using InvoiceApp.Models;
using InvoiceApp.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InvoiceApp.Pages.Invoices
{
    public class EditModel : PageModel
    {
        public InvoiceDTO InvoiceDTO { get; set; } = new InvoiceDTO();

        public Invoice Invoice { get; set; } = new();

        private readonly ApplicationDBContext dbContext;

        public EditModel(ApplicationDBContext applicationDBContext)
        {
            dbContext = applicationDBContext;
        }

        public IActionResult OnGet(int id)
        {
            var invoices = dbContext.Invoices.Find(id);

            if(invoices== null)
            {
                return RedirectToPage("/Invoices/Index");
            }

            Invoice = invoices;
            InvoiceDTO.Number = invoices.Number;
            InvoiceDTO.Status = invoices.Status;
            InvoiceDTO.IssueDate = invoices.IssueDate;
            InvoiceDTO.DueDate = invoices.DueDate;

            InvoiceDTO.Services = invoices.Services;
            InvoiceDTO.UnitPrice = invoices.UnitPrice;
            InvoiceDTO.Quantity = invoices.Quantity;

            InvoiceDTO.ClientName = invoices.ClientName;
            InvoiceDTO.Email = invoices.Email;
            InvoiceDTO.Phone = invoices.Phone;
            InvoiceDTO.Address = invoices.Address;

            return Page();

        }

        public string successMessage = string.Empty;
        public IActionResult OnPost(int id)
        {
            var invoices = dbContext.Invoices.Find(id);
            if(invoices == null)
            {
                return RedirectToPage("/Invoices/Index");
            }

            Invoice= invoices;

            if(!ModelState.IsValid)
            {
                return Page();
            }

            invoices.Number = InvoiceDTO.Number;
            invoices.Status = InvoiceDTO.Status;
            invoices.IssueDate = InvoiceDTO.IssueDate;
            invoices.DueDate = InvoiceDTO.DueDate;

            invoices.Services = InvoiceDTO.Services;
            invoices.UnitPrice = InvoiceDTO.UnitPrice;
            invoices.Quantity = InvoiceDTO.Quantity;

            invoices.ClientName = InvoiceDTO.ClientName;
            invoices.Email = InvoiceDTO.Email;
            invoices.Phone = InvoiceDTO.Phone;
            invoices.Address = InvoiceDTO.Address;

            dbContext.SaveChanges();

            successMessage = "Invoice updated successfully!";

            return Page();

        }
    }
}
