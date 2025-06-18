using InvoiceApp.Models;
using InvoiceApp.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InvoiceApp.Pages.Invoices
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext _applicationDBContext;
        public List<Invoice> InvoiceList = new();
        public IndexModel(ApplicationDBContext applicationDBContext)
        {
            this._applicationDBContext = applicationDBContext;
        }
        public void OnGet()
        {
            InvoiceList = _applicationDBContext.Invoices.OrderByDescending(i => i.Id).ToList();
        }
    }
}
