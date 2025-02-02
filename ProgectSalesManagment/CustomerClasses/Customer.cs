using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgectSalesManagment.CustomerClasses
{
    internal class Customer
    {
        public int CustomerID{ get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        // public List<Invoice> Invoices { get; set; }
    }
}
