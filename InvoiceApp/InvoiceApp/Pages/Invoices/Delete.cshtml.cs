using InvoiceApp.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InvoiceApp.Pages.Invoices
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDBContext _applicationDBContext;
        public DeleteModel(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }
        public IActionResult OnGet(int id)
        {
            var invoice= _applicationDBContext.Invoices.Find(id);

            if(invoice != null)
            {
                _applicationDBContext.Invoices.Remove(invoice);
                _applicationDBContext.SaveChanges();
            }

            return RedirectToPage("/Invoices/Index");
        }
    }
}
