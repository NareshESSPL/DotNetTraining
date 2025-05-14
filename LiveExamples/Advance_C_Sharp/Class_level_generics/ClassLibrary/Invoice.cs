using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Invoice : Document
    {
        public int InvoiceId { get; set; }
        public string InvoiceName { get; set; }
    }
}
