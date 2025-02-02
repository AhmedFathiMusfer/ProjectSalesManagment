using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgectSalesManagment
{
    internal class Enums
    {
        internal enum MenuOptions
        {
            CustomerManagement,
            SaleInvoiceManagement,
            ProductManagement,
            SalesmanManagement,
            WarehouseManagement,
            SaleOperation,
            AddCategorey,
        }
        internal enum CustomerOptions
        {
            AddCustomer,
            DeleteCustomer,
            UpdateCustomer,
            ViewCustomerById,
            ViewAllCustomer,
            Ouit
        }
        internal enum ProductOptions
        {
            AddProduct,
            DeleteProduct,
            UpdateProduct,
            ViewProductById,
            ViewAllProduct,
            Ouit
        }
        internal enum SlaesmaneOptions
        {
            AddSalesmane,
            DeleteSalesmane,
            UpdateSalesmane,
            ViewSalesmaneById,
            ViewAllSlaesmane,
            Ouit
        }
        internal enum WarehouseOptions
        {
            AddWarehouse,
            DeleteWarehouse,
            UpdateWarehouse,
            ViewWarehouseByID,
            ViewAllWarehouse,
            Ouit
        }
        internal enum SaleInvoiceOptions
        {
            AddSaleInvoice,
            DeleteSaleInvoice,
            UpdateSaleInvoice,
            ViewSaleInvoiceByID,
            ViewAllSaleInvoice,
            Ouit
        }
        internal enum SaleOperationOptions
        {
            AddSaleOperation,
            DeleteSaleOperation,
            UpdateSaleOperation,
            ViewSaleOperationByID,
            ViewAllSaleOperation,
            Ouit
        }
    }
}
