using Spectre.Console;

namespace ProgectSalesManagment.CustomerClasses
{
    internal class CustomerService
    {
        internal static void DeleteCustomer()
        {
            var customer = GetCustomerOpttionInput();
            CustomerController.Delete(customer);
        }

        static internal void InsertCustomer()
        {
            var customer = new Customer();
            customer.CustomerID = CustomerController.GetID();
            customer.Name = AnsiConsole.Ask<string>("Product's name:");
            customer.Address = AnsiConsole.Ask<string>("Product's Adderss:");
            customer.Phone = AnsiConsole.Ask<string>("Product's Phone:");

            CustomerController.AddNew(customer);
        }

        internal static void ViewCustomerById()
        {
            var customer=GetCustomerOpttionInput();
            var panel = new Panel($@"ID:{customer.CustomerID}
Name: {customer.Name}
Address: {customer.Address}
Phone: {customer.Phone}");

            panel.Header = new PanelHeader("Product Info");
            panel.Padding = new Padding(2, 2, 2, 2);
            AnsiConsole.Write(panel);

            Console.WriteLine("Enter any Key to continue");
            Console.ReadLine();
        }

        internal static void ViewCustomers()
        {
            var customers = CustomerController.GetAll();
            ShowCustomersTable(customers);
        }
        internal static void UpdateCustomer()
        {
            var customer = GetCustomerOpttionInput();
            customer.Name = AnsiConsole.Confirm("Update name?") ?
             AnsiConsole.Ask<string>("Product's new name:")
             : customer.Name;

            customer.Address = AnsiConsole.Confirm("Update Address?") ?
             AnsiConsole.Ask<string>("Product's new address:")
             : customer.Address;
            customer.Phone = AnsiConsole.Confirm("Update Phone?") ?
             AnsiConsole.Ask<string>("Product's new Phone:")
             : customer.Phone;
            CustomerController.Update(customer);

        }



        static void ShowCustomersTable(List<Customer> customers)
        {
            Table table = new Table();
            table.AddColumn("Product Id");
            table.AddColumn("Name");
            table.AddColumn("Adderss");
            table.AddColumn("Phone");

            foreach (Customer customer in customers)
            {
                table.AddRow(customer.CustomerID.ToString(),customer.Name,customer.Address,customer.Phone);
            }
            AnsiConsole.Write(table);

            Console.WriteLine("Enter any Key to continue");
            Console.ReadLine();
            Console.Clear();

        }
        static internal Customer GetCustomerOpttionInput()
        {
            var customers = CustomerController.GetAll();
            var customersArray = customers.Select(x => x.Name).ToArray();
            var option = AnsiConsole.Prompt(new SelectionPrompt<string>().
                Title("Choose Product:").
                AddChoices(customersArray));
            var id = customers.Single(x => x.Name == option).CustomerID;
            var customer = CustomerController.GetByID(id);

            return customer;
        }

    }
}
