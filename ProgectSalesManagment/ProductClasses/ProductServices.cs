using ProgectSalesManagment.CustomerClasses;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgectSalesManagment.ProductClasses
{
    internal class ProductServices
    {
        internal static void DeleteProduct()
        {
            var product = GetProductOpttionInput();
            ProductController.Delete(product);
        }

        static internal void InsertProduct()
        {
            var product = new Product();
            product.ProductId = ProductController.GetID();
            product.Name = AnsiConsole.Ask<string>("Product's name:");      
            product.Price = AnsiConsole.Ask<decimal>("Product's Price:");
            product.Quantity = AnsiConsole.Ask<int>("Product's Quantity:");
            product.Unit= AnsiConsole.Ask<string>("Product's Unit:");

            ProductController.AddNew(product);
        }

        internal static void ViewProductById()
        {
            var product = GetProductOpttionInput();
            var panel = new Panel($@"ID:{product.ProductId}
Name: {product.Name}
Price: {product.Price}
Quantity: {product.Quantity}
Unit: {product.Unit}");

            panel.Header = new PanelHeader("Product Info");
            panel.Padding = new Padding(2, 2, 2, 2);
            AnsiConsole.Write(panel);

            Console.WriteLine("Enter any Key to continue");
            Console.ReadLine();
        }

        internal static void ViewProducts()
        {
            var products = ProductController.GetAll();
            ShowProductsTable(products);
        }
        internal static void UpdateProduct()
        {
            var product = GetProductOpttionInput();
            product.Name = AnsiConsole.Confirm("Update name?") ?
             AnsiConsole.Ask<string>("Product's new name:")
             : product.Name;

            product.Price = AnsiConsole.Confirm("Update price?") ?
             AnsiConsole.Ask<decimal>("Product's new price:")
             : product.Price;
            product.Quantity = AnsiConsole.Confirm("Update quantity?") ?
             AnsiConsole.Ask<int>("Product's new quantity:")
             : product.Quantity;

            product.Unit = AnsiConsole.Confirm("Update unit?") ?
             AnsiConsole.Ask<string>("Product's new unit:")
             : product.Unit;
            ProductController.Update(product);

        }



        static void ShowProductsTable(List<Product> products)
        {
            Table table = new Table();
            table.AddColumn("Product Id");
            table.AddColumn("Name");
            table.AddColumn("Price");
            table.AddColumn("Quantity");
            table.AddColumn("Unit");

            foreach (Product product in products)
            {
              // table.AddRow(product.ProductId.ToString,product.Name,product.Price.ToString,product.Quantity.ToString,product.Unit);
            }
            AnsiConsole.Write(table);

            Console.WriteLine("Enter any Key to continue");
            Console.ReadLine();
            Console.Clear();

        }
        static internal Product GetProductOpttionInput()
        {
            var products = ProductController.GetAll();
            var productsArray = products.Select(x => x.Name).ToArray();
            var option = AnsiConsole.Prompt(new SelectionPrompt<string>().
                Title("Choose Product:").
                AddChoices(productsArray));
            var id = products.Single(x => x.Name == option).ProductId;
            var product =ProductController.GetByID(id);

            return product;
        }
    }
}
