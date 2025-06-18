using InvoiceApp.Models;
using InvoiceApp.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InvoiceApp.Pages.Invoices
{

    public class CreateModel : PageModel
    {
        private readonly ApplicationDBContext dbContext;
        [BindProperty]
        public InvoiceDTO InvoiceDTO { get; set; } = new();

        public CreateModel(ApplicationDBContext applicationDBContext)
        {
            dbContext = applicationDBContext;
        }
        public void OnGet()
        {

        }

        public IActionResult OnPost() {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var invoice = new Invoice
            {
                Number=InvoiceDTO.Number,
                Status=InvoiceDTO.Status,
                IssueDate=InvoiceDTO.IssueDate, 
                DueDate=InvoiceDTO.DueDate,

                Services=InvoiceDTO.Services,
                UnitPrice=InvoiceDTO.UnitPrice,
                Quantity=InvoiceDTO.Quantity,

                ClientName=InvoiceDTO.ClientName,   
                Email=InvoiceDTO.Email,
                Phone=InvoiceDTO.Phone,
                Address=InvoiceDTO.Address,
            };
            dbContext.Invoices.Add(invoice);
            dbContext.SaveChanges();

            return RedirectToPage("/Invoice/Index");
        }    
    }
}
