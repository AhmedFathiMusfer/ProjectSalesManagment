using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgectSalesManagment.SalesPersonClasses
{
    internal class SalesPerosnService
    {
        internal static void Deletesalesperson()
        {
            var salesperson = GetSalespersonOpttionInput();
            SalesPersonController.Delete(salesperson);
        }

        static internal void InsertSalesperson()
        {
            var salesperson = new Salesperson();
            salesperson.SalespersonId = SalesPersonController.GetID();
            salesperson.Name = AnsiConsole.Ask<string>("Product's name:");
            salesperson.Phone = AnsiConsole.Ask<string>("Product's Phone:");

            SalesPersonController.AddNew(salesperson);
        }

        internal static void ViewSalespersonById()
        {
            var salesperson = GetSalespersonOpttionInput();
            var panel = new Panel($@"ID:{salesperson.SalespersonId}
Name: {salesperson.Name}
Phone: {salesperson.Phone}");

            panel.Header = new PanelHeader("Product Info");
            panel.Padding = new Padding(2, 2, 2, 2);
            AnsiConsole.Write(panel);

            Console.WriteLine("Enter any Key to continue");
            Console.ReadLine();
        }
        internal static void ViewSalespersons()
        {
            var salespersons = SalesPersonController.GetAll();
            ShowSalespersonsTable(salespersons);
        }

        internal static void UpdateSalesperson()
        {
            var salesperson = GetSalespersonOpttionInput();
            salesperson.Name = AnsiConsole.Confirm("Update name?") ?
             AnsiConsole.Ask<string>("Product's new name:")
             : salesperson.Name;


            salesperson.Phone = AnsiConsole.Confirm("Update Phone?") ?
             AnsiConsole.Ask<string>("Product's new Phone:")
             : salesperson.Phone;
            SalesPersonController.Update(salesperson);

        }


        static void ShowSalespersonsTable(List<Salesperson> salespersons)
        {
            Table table = new Table();
            table.AddColumn("SalesPerson Id");
            table.AddColumn("Name");
            table.AddColumn("Phone");

            foreach (Salesperson salesperson in salespersons)
            {
                table.AddRow(salesperson.SalespersonId.ToString(), salesperson.Name, salesperson.Phone);
            }
            AnsiConsole.Write(table);

            Console.WriteLine("Enter any Key to continue");
            Console.ReadLine();
            Console.Clear();

        }

        static internal Salesperson GetSalespersonOpttionInput()
        {
            var salespersons = SalesPersonController.GetAll();
            var salespersonsArray = salespersons.Select(x => x.SalespersonId).ToArray();
            var option = AnsiConsole.Prompt(new SelectionPrompt<int>().
                Title("Choose Product:").
                AddChoices(salespersonsArray));
            var id = salespersons.Single(x => x.SalespersonId == option).SalespersonId;
            var salesperson = SalesPersonController.GetByID(id);

            return salesperson;
        }
    }
}
