namespace InvoiceApp.Models
{
    public class ErrorViewModel
    {
        public string? RequectId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequectId);
    }
}
