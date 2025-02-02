using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgectSalesManagment.SalesInvoiceClasses
{
    internal class SaleInvoice
    {
        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int CustomerId { get; set; }
        public int SalesOpersonId { get; set; }
        public int SalesManeId { get; set; }

        // public List<Operation> Operations { get; set; }
    }
}
