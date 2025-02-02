



using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgectSalesManagment.WarehouseClasses
{

    

    internal class WarehouseService
    {

        internal static void DeleteWarehouse()
        {
            var warehouse = GetWarehouseOpttionInput();
            WarehouseController.Delete(warehouse);
        }
        static internal void InsertWarehouse()
        {
            var warehouse = new Warehouse();
            warehouse.WarehouseId= WarehouseController.GetID();
            warehouse.Address = AnsiConsole.Ask<string>("Product's Adderss:");

            WarehouseController.AddNew(warehouse);
        }

        internal static void ViewWarehouseById()
        {
            var warehouse = GetWarehouseOpttionInput();
            var panel = new Panel($@"ID:{warehouse.WarehouseId}
             Address: {warehouse.Address}");

            panel.Header = new PanelHeader("Product Info");
            panel.Padding = new Padding(2, 2, 2, 2);
            AnsiConsole.Write(panel);

            Console.WriteLine("Enter any Key to continue");
            Console.ReadLine();
        }

        internal static void ViewWarehouses()
        {
            var warehouses = WarehouseController.GetAll();
            ShowWarehousesTable(warehouses);
        }

            internal static void UpdateWarehouse()
            {
                var warehouse = GetWarehouseOpttionInput();
                warehouse.Address = AnsiConsole.Confirm("Update Address?") ?
                 AnsiConsole.Ask<string>("Product's new Address:")
                 : warehouse.Address;


                WarehouseController.Update(warehouse);

            }
            static void ShowWarehousesTable(List<Warehouse> warehouses)
            {
                Table table = new Table();
                table.AddColumn("Product Id");
                table.AddColumn("Adderss");


                foreach (Warehouse warehouse in warehouses)
                {
                    table.AddRow(warehouse.WarehouseId.ToString(), warehouse.Address);
                }
                AnsiConsole.Write(table);

                Console.WriteLine("Enter any Key to continue");
                Console.ReadLine();
                Console.Clear();

            }
            internal static Warehouse GetWarehouseOpttionInput()
            {
                var warehouses = WarehouseController.GetAll();
                var warehousesArray = warehouses.Select(x => x.Address).ToArray();
                var option = AnsiConsole.Prompt(new SelectionPrompt<string>().
                    Title("Choose Product:").
                    AddChoices(warehousesArray));
                var id = warehouses.Single(x => x.Address == option).WarehouseId;
                var warehouse = WarehouseController.GetByID(id);

                return warehouse;
            }
    }
}
