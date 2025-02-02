using ProgectSalesManagment.CustomerClasses;
using ProgectSalesManagment.ProductClasses;
using ProgectSalesManagment.SalesInvoiceClasses;
using ProgectSalesManagment.SalesPersonClasses;
using ProgectSalesManagment.WarehouseClasses;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProgectSalesManagment.Enums;

namespace ProgectSalesManagment
{
    internal class UserIntervice
    {
        static public void MainMenu()
        {
            var isAppRunning = true;
            while (isAppRunning)
            {
                var option = AnsiConsole.Prompt(
                 new SelectionPrompt<MenuOptions>()
                 .Title("Whate would you like to do?")
                 .AddChoices(
                     MenuOptions.ProductManagement,
                     MenuOptions.SaleInvoiceManagement,
                     MenuOptions.CustomerManagement,
                     MenuOptions.SalesmanManagement,
                     MenuOptions.WarehouseManagement,
                     MenuOptions.SaleOperation
                    ));

                switch (option)
                {
                    case MenuOptions.ProductManagement:
                        ProductMenu();
                        break;
                    case MenuOptions.SaleInvoiceManagement:
                        SaleInvoicMenu();
                        break;
                    case MenuOptions.CustomerManagement:
                        CustomerMenu();
                        break;
                    case MenuOptions.SalesmanManagement:
                        SalesmaneMenu();
                        break;
                    case MenuOptions.SaleOperation:
                        SaleOperationMenu();
                        break;
                    case MenuOptions.WarehouseManagement:
                        WarehouseMenu();
                        break;
                }
            }
        }

        private static void WarehouseMenu()
        {
            var isAppRunning = true;
            while (isAppRunning)
            {
                var option = AnsiConsole.Prompt(
                 new SelectionPrompt<WarehouseOptions>()
                 .Title("Whate would you like to do?")
                 .AddChoices(
                     WarehouseOptions.AddWarehouse,
                     WarehouseOptions.DeleteWarehouse,
                     WarehouseOptions.ViewWarehouseByID,
                     WarehouseOptions.ViewAllWarehouse,
                     WarehouseOptions.UpdateWarehouse,
                     WarehouseOptions.Ouit));

                switch (option)
                {
                    case WarehouseOptions.AddWarehouse:
                        WarehouseService.InsertWarehouse();
                        break;
                    case WarehouseOptions.DeleteWarehouse:
                        WarehouseService.DeleteWarehouse();
                        break;
                    case WarehouseOptions.ViewWarehouseByID:
                        WarehouseService.ViewWarehouseById();

                        break;
                    case WarehouseOptions.ViewAllWarehouse:
                        WarehouseService.ViewWarehouses();
                        break;
                    case WarehouseOptions.UpdateWarehouse:
                        WarehouseService.UpdateWarehouse(); 
                        break;
                    case WarehouseOptions.Ouit:
                        MainMenu();
                        break;
                }

            }
            throw new NotImplementedException();
        }

        private static void SaleOperationMenu()
        {

            throw new NotImplementedException();
        }

        private static void SalesmaneMenu()
        {
            var isAppRunning = true;
            while (isAppRunning)
            {
                var option = AnsiConsole.Prompt(
                 new SelectionPrompt<SlaesmaneOptions>()
                 .Title("Whate would you like to do?")
                 .AddChoices(
                     SlaesmaneOptions.AddSalesmane,
                     SlaesmaneOptions.DeleteSalesmane,
                     SlaesmaneOptions.ViewSalesmaneById,
                     SlaesmaneOptions.ViewAllSlaesmane,
                     SlaesmaneOptions.UpdateSalesmane,
                     SlaesmaneOptions.Ouit));

                switch (option)
                {
                    case SlaesmaneOptions.AddSalesmane:
                        SalesPerosnService.InsertSalesperson();
                        break;
                    case SlaesmaneOptions.DeleteSalesmane:
                        SalesPerosnService.Deletesalesperson();
                        break;
                    case SlaesmaneOptions.ViewSalesmaneById:
                        SalesPerosnService.ViewSalespersonById();

                        break;
                    case SlaesmaneOptions.ViewAllSlaesmane:
                        SalesPerosnService.ViewSalespersons();
                        break;
                    case SlaesmaneOptions.UpdateSalesmane:
                        SalesPerosnService.UpdateSalesperson();
                        break;
                    case SlaesmaneOptions.Ouit:
                        MainMenu();
                        break;
                }

            }
        }

        private static void CustomerMenu()
        {
            var isAppRunning = true;
            while (isAppRunning)
            {
                var option = AnsiConsole.Prompt(
                 new SelectionPrompt<CustomerOptions>()
                 .Title("Whate would you like to do?")
                 .AddChoices(
                     CustomerOptions.AddCustomer,
                     CustomerOptions.DeleteCustomer,
                     CustomerOptions.ViewCustomerById,
                     CustomerOptions.ViewAllCustomer,
                     CustomerOptions.UpdateCustomer,
                     CustomerOptions.Ouit));

                switch (option)
                {
                    case CustomerOptions.AddCustomer:
                        CustomerService.InsertCustomer();
                        break;
                    case CustomerOptions.DeleteCustomer:
                        CustomerService.DeleteCustomer();
                        break;
                    case CustomerOptions.ViewCustomerById:
                         CustomerService.ViewCustomerById();

                        break;
                    case CustomerOptions.ViewAllCustomer:
                        CustomerService.ViewCustomers();
                        break;
                    case CustomerOptions.UpdateCustomer:
                         CustomerService.UpdateCustomer();
                        break;
                    case CustomerOptions.Ouit:
                        MainMenu();
                        break;
                }

            }
        }

        private static void SaleInvoicMenu()
        {
            var isAppRunning = true;
            while (isAppRunning)
            {
                var option = AnsiConsole.Prompt(
                 new SelectionPrompt<SaleInvoiceOptions>()
                 .Title("Whate would you like to do?")
                 .AddChoices(
                     SaleInvoiceOptions.AddSaleInvoice,
                     SaleInvoiceOptions.DeleteSaleInvoice,
                     SaleInvoiceOptions.UpdateSaleInvoice,
                     SaleInvoiceOptions.ViewSaleInvoiceByID,
                     SaleInvoiceOptions.ViewAllSaleInvoice,
                     SaleInvoiceOptions.Ouit
                     ));

                switch (option)
                {
                    case SaleInvoiceOptions.AddSaleInvoice:
                        SaleInvoiceService.InsertSaleInvoice();
                        break;
                    case SaleInvoiceOptions.DeleteSaleInvoice:
                        SaleInvoiceService.DeleteSaleInvoice();
                        break;
                    case SaleInvoiceOptions.UpdateSaleInvoice:
                        SaleInvoiceService.UpdateSaleInvoice();

                        break;
                    case SaleInvoiceOptions.ViewSaleInvoiceByID:
                        SaleInvoiceService.ViewSaleInvoiceById();
                        break;
                    case SaleInvoiceOptions.ViewAllSaleInvoice:
                        SaleInvoiceService.ViewAllSaleInvoices();
                        break;
                    case SaleInvoiceOptions.Ouit:
                        MainMenu();
                        break;
                }

            }
        }

        private static void ProductMenu()
        {

            var isAppRunning = true;
            while (isAppRunning)
            {
                var option = AnsiConsole.Prompt(
                 new SelectionPrompt<ProductOptions>()
                 .Title("Whate would you like to do?")
                 .AddChoices(
                     ProductOptions.AddProduct,
                     ProductOptions.UpdateProduct,
                     ProductOptions.DeleteProduct,
                     ProductOptions.ViewProductById,
                     ProductOptions.ViewAllProduct,
                     ProductOptions.Ouit
                     ));

                switch (option)
                {
                    case ProductOptions.AddProduct:
                        ProductServices.InsertProduct(); 
                        break;
                    case ProductOptions.DeleteProduct:
                        ProductServices.DeleteProduct();
                        break;
                    case ProductOptions.ViewProductById:
                        ProductServices.ViewProductById();
                        break;
                    case ProductOptions.ViewAllProduct:
                        ProductServices.ViewProducts();
                        break;
                    case ProductOptions.UpdateProduct:
                        ProductServices.UpdateProduct();
                        break;
                    case ProductOptions.Ouit:
                        MainMenu();
                        break;
                       
                }

            }
        }

    }
}
