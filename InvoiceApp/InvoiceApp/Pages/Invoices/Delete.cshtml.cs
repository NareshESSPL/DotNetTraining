using InvoiceApp.Models;
using InvoiceApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InvoiceApp.Pages.Invoices
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public DeleteModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public Invoice Invoice { get; set; }

        public IActionResult OnGet(string number)
        {
            Invoice = context.Invoices.FirstOrDefault(i => i.Number == number);

            if (Invoice == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            var invoice = context.Invoices.FirstOrDefault(i => i.Number == Invoice.Number);

            if (invoice == null)
            {
                return NotFound();
            }

            context.Invoices.Remove(invoice);
            context.SaveChanges();

            return RedirectToPage("/Invoices/Index");
        }
    }
}
