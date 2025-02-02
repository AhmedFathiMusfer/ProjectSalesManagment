using ProgectSalesManagment.ProductClasses;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgectSalesManagment.SalesInvoiceClasses
{
    internal class SaleInvoiceService
    {
        internal static void DeleteSaleInvoice()
        {
            var invoice = GetInvoiceOpttionInput();
            SaleInvoiceController.Delete(invoice);
        }

        internal static void InsertSaleInvoice()
        {
            var invoice = new SaleInvoice();
            invoice.InvoiceId= SaleInvoiceController.GetID();
            invoice.InvoiceDate =DateTime.Today;
            invoice.SalesManeId = AnsiConsole.Ask<int>("SalesMane's ID:");
            invoice.SalesOpersonId = AnsiConsole.Ask<int>("SalesOperation's ID:");
            invoice.CustomerId = AnsiConsole.Ask<int>("Customer's Id:");

            SaleInvoiceController.AddNew(invoice);
        }

        internal static void UpdateSaleInvoice()
        {
            var Invoice = GetInvoiceOpttionInput(); ;
            Invoice.SalesManeId = AnsiConsole.Confirm("Update SalesMane Id?") ?
             AnsiConsole.Ask<int>("Invoice's new SalesMane Id:")
             : Invoice.SalesManeId;

            Invoice.CustomerId = AnsiConsole.Confirm("Update Customer Id?") ?
             AnsiConsole.Ask<int>("Invoice's new Customer Id:")
             : Invoice.CustomerId;
            Invoice.SalesOpersonId = AnsiConsole.Confirm("Update SaleOperation Id?") ?
             AnsiConsole.Ask<int>("Invoice's new SaleOperation Id:")
             : Invoice.SalesOpersonId;


            SaleInvoiceController.Update(Invoice);
        }

        internal static void ViewSaleInvoiceById()
        {
            var invoice = GetInvoiceOpttionInput();
            var panel = new Panel($@"ID:{invoice.InvoiceId}
Date: {invoice.InvoiceDate}
Salesmane Id: {invoice.SalesManeId}
Customer Id: {invoice.CustomerId}
SaleOperation Id: {invoice.SalesOpersonId}");

            panel.Header = new PanelHeader("Sale Invoice Info");
            panel.Padding = new Padding(2, 2, 2, 2);
            AnsiConsole.Write(panel);

            Console.WriteLine("Enter any Key to continue");
            Console.ReadLine();
        }

        internal static void ViewAllSaleInvoices()
        {
            throw new NotImplementedException();
        
        }

        static internal SaleInvoice GetInvoiceOpttionInput()
        {
            var invoices = SaleInvoiceController.GetAll();
            var invoicesArray = invoices.Select(x => x.InvoiceId).ToArray();
            var option = AnsiConsole.Prompt(new SelectionPrompt<int>().
                Title("Choose Product:").
                AddChoices(invoicesArray));
            var id = invoices.Single(x => x.InvoiceId == option).InvoiceId;
            var invoice = SaleInvoiceController.GetByID(id);

            return invoice;
        }
    }
}
