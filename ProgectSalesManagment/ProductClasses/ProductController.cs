using Newtonsoft.Json;
using ProgectSalesManagment.CustomerClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgectSalesManagment.ProductClasses
{
    internal class ProductController
    {
        private static readonly string ProductsFilePath = "ProductsFile.text";

        internal static int GetID()
        {

            var JsonContent = File.ReadAllText(ProductsFilePath);
            var products = JsonConvert.DeserializeObject<List<Product>>(JsonContent);
            var productId = products[products.Count - 1].ProductId;
            return productId + 1;

        }
        internal static List<Product> GetAll()
        {
            var products = new List<Product>();

            if (File.ReadAllText(ProductsFilePath) != " ")
            {
                products = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText(ProductsFilePath));


                return products;
            }
            else { return products; }
        }

        internal static Product GetByID(int productId)
        {

            var products = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText(ProductsFilePath));


            var product = products.FirstOrDefault(i => i.ProductId == productId);


            return product;
        }

        internal static void AddNew(Product product)
        {
            List<Product> products = new List<Product>();
            if (File.ReadAllText(ProductsFilePath) != string.Empty)
            {
                products = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText(ProductsFilePath));
            }


            products.Add(product);


            File.WriteAllText(ProductsFilePath, JsonConvert.SerializeObject(products));
        }

        internal static void Update(Product product)
        {

            var products = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText(ProductsFilePath));


            var productToUpdate = products.FirstOrDefault(i => i.ProductId == product.ProductId);


            productToUpdate.ProductId = product.ProductId;
            productToUpdate.Name = product.Name;
            productToUpdate.Unit = product.Unit;
            productToUpdate.Price = product.Price;
            productToUpdate.Quantity = product.Quantity;


            File.WriteAllText(ProductsFilePath, JsonConvert.SerializeObject(products));
        }

        internal static void Delete(Product product)
        {

            var products = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText(ProductsFilePath));


            var productToDelete = products.FirstOrDefault(i => i.ProductId == product.ProductId);

            products.Remove(productToDelete);


            File.WriteAllText(ProductsFilePath, JsonConvert.SerializeObject(products));
        }
    }
}
