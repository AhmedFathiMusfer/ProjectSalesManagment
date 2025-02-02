using Newtonsoft.Json;
using ProgectSalesManagment.CustomerClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgectSalesManagment.SalesInvoiceClasses
{
    internal class SaleInvoiceController
    {
        private static readonly string SaleInvoiceFilePath = "SaleInvoiceFile.text";

        internal static int GetID()
        {

            var JsonContent = File.ReadAllText(SaleInvoiceFilePath);
            var saleInvoices = JsonConvert.DeserializeObject<List<SaleInvoice>>(JsonContent);
            var SaleInvoiceID = saleInvoices[saleInvoices.Count - 1].InvoiceId;
            return SaleInvoiceID + 1;

        }
        internal static List<SaleInvoice> GetAll()
        {
            var saleInvoices = new List<SaleInvoice>();

            if (File.ReadAllText(SaleInvoiceFilePath) != " ")
            {
                saleInvoices = JsonConvert.DeserializeObject<List<SaleInvoice>>(File.ReadAllText(SaleInvoiceFilePath));


                return saleInvoices;
            }
            else { return saleInvoices; }
        }

        internal static SaleInvoice GetByID(int saleInvoiceId)
        {

            var saleInvoices = JsonConvert.DeserializeObject<List<SaleInvoice>>(File.ReadAllText(SaleInvoiceFilePath));


            var saleInvoice = saleInvoices.FirstOrDefault(i => i.InvoiceId== saleInvoiceId);


            return saleInvoice;
        }

        internal static void AddNew(SaleInvoice saleInvoice)
        {
            List<SaleInvoice> saleInvoices = new List<SaleInvoice>();
            if (File.ReadAllText(SaleInvoiceFilePath) != string.Empty)
            {
                saleInvoices = JsonConvert.DeserializeObject<List<SaleInvoice>>(File.ReadAllText(SaleInvoiceFilePath));
            }


            saleInvoices.Add(saleInvoice);


            File.WriteAllText(SaleInvoiceFilePath, JsonConvert.SerializeObject(saleInvoices));
        }

        internal static void Update(SaleInvoice saleInvoice)
        {

            var saleInvoices = JsonConvert.DeserializeObject<List<SaleInvoice>>(File.ReadAllText(SaleInvoiceFilePath));


            var saleInvoiceToUpdate = saleInvoices.FirstOrDefault(i => i.InvoiceId == saleInvoice.InvoiceId);


            saleInvoiceToUpdate.InvoiceId = saleInvoice.InvoiceId;
            saleInvoiceToUpdate .InvoiceDate= saleInvoice.InvoiceDate;
            saleInvoiceToUpdate.CustomerId = saleInvoice.CustomerId;
            saleInvoiceToUpdate.SalesOpersonId = saleInvoice.SalesOpersonId;
            saleInvoiceToUpdate.SalesManeId = saleInvoice.SalesManeId;


            File.WriteAllText(SaleInvoiceFilePath, JsonConvert.SerializeObject(saleInvoices));
        }

        internal static void Delete(SaleInvoice saleInvoice)
        {

            var saleInvoices = JsonConvert.DeserializeObject<List<SaleInvoice>>(File.ReadAllText(SaleInvoiceFilePath));


            var customerToDelete = saleInvoices.FirstOrDefault(i => i.InvoiceId == saleInvoice.InvoiceId);

            saleInvoices.Remove(customerToDelete);


            File.WriteAllText(SaleInvoiceFilePath, JsonConvert.SerializeObject(saleInvoices));
        }
    }
}
