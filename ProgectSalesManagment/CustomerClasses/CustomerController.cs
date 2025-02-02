using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProgectSalesManagment.CustomerClasses
{
    internal class CustomerController
    {
        private static readonly string customersFilePath ="CustomersFile.text";

        internal static int GetID()
        {
           
            var JsonContent = File.ReadAllText(customersFilePath);
            var customers = JsonConvert.DeserializeObject<List<Customer>>(JsonContent);
            var customerId = customers[customers.Count - 1].CustomerID;
            return customerId+1;

        }
        internal static List<Customer> GetAll()
        {
            var customers = new List<Customer>();

            if (File.ReadAllText(customersFilePath) != " ")
            {
                customers = JsonConvert.DeserializeObject<List<Customer>>(File.ReadAllText(customersFilePath));


                return customers;
            }
            else { return customers; }
        }

        internal static Customer GetByID(int customerId)
        {

            var customers = JsonConvert.DeserializeObject<List<Customer>>(File.ReadAllText(customersFilePath));


            var customer = customers.FirstOrDefault(i => i.CustomerID == customerId);


            return customer;
        }

        internal static void AddNew(Customer customer)
        {
            List<Customer> customers = new List<Customer>();
            if (File.ReadAllText(customersFilePath) != string.Empty)
            {
                customers = JsonConvert.DeserializeObject<List<Customer>>(File.ReadAllText(customersFilePath));
            }


            customers.Add(customer);


            File.WriteAllText(customersFilePath, JsonConvert.SerializeObject(customers));
        }

        internal static void Update(Customer customer)
        {

            var customers = JsonConvert.DeserializeObject<List<Customer>>(File.ReadAllText(customersFilePath));


            var customerToUpdate = customers.FirstOrDefault(i => i.CustomerID == customer.CustomerID);


            customerToUpdate.CustomerID = customer.CustomerID;
            customerToUpdate.Name = customer.Name;
            customerToUpdate.Address = customer.Address;
            customerToUpdate.Phone = customer.Phone;


            File.WriteAllText(customersFilePath, JsonConvert.SerializeObject(customers));
        }

        internal static void Delete(Customer customer)
        {

            var customers = JsonConvert.DeserializeObject<List<Customer>>(File.ReadAllText(customersFilePath));


            var customerToDelete = customers.FirstOrDefault(i => i.CustomerID == customer.CustomerID);

            customers.Remove(customerToDelete);


            File.WriteAllText(customersFilePath, JsonConvert.SerializeObject(customers));
        }
    }
}
