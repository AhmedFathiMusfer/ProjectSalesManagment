using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgectSalesManagment.SalesPersonClasses
{
    internal class SalesPersonController
    {


        private static readonly string salespersonsFilePath = "SalesPersonsFile.text";

        internal static int GetID()
        {
            if (File.Exists(salespersonsFilePath))
            {

                if (File.ReadAllText(salespersonsFilePath)==" ")
                {
                    return 1;
                }
                else {
                    var JsonContent = File.ReadAllText(salespersonsFilePath);
                    var salespersons = JsonConvert.DeserializeObject<List<Salesperson>>(JsonContent);
                    var salespersonId = salespersons[salespersons.Count - 1].SalespersonId;
                    return salespersonId + 1;

                    }
            }
            else
            {
                return 1;
            }

        }


        internal static List<Salesperson> GetAll()
        {
            var salespersons = new List<Salesperson>();
            if (File.ReadAllText(salespersonsFilePath)!= " ")
            {

                salespersons = JsonConvert.DeserializeObject<List<Salesperson>>(File.ReadAllText(salespersonsFilePath));


                return salespersons;
            }
            else { return salespersons; }
        }

        internal static Salesperson GetByID(int salespersonId)
        {

            var salespersons = JsonConvert.DeserializeObject<List<Salesperson>>(File.ReadAllText(salespersonsFilePath));


            var salesperson = salespersons.FirstOrDefault(i => i.SalespersonId == salespersonId);
            return salesperson;
        }

        internal static void AddNew(Salesperson salesperson)
        {
            
            List<Salesperson> salespersons = new List<Salesperson>();
            if (File.ReadAllText(salespersonsFilePath)!=" " && File.Exists(salespersonsFilePath))
            {
                salespersons = JsonConvert.DeserializeObject<List<Salesperson>>(File.ReadAllText(salespersonsFilePath));
            }


            salespersons.Add(salesperson);


            File.WriteAllText(salespersonsFilePath, JsonConvert.SerializeObject(salespersons));
        }
        internal static void Update(Salesperson salesperson)
        {

            var salespersons = JsonConvert.DeserializeObject<List<Salesperson>>(File.ReadAllText(salespersonsFilePath));


            var salespersonToUpdate = salespersons.FirstOrDefault(i => i.SalespersonId == salesperson.SalespersonId);


            salespersonToUpdate.SalespersonId = salesperson.SalespersonId;
            salespersonToUpdate.Name = salesperson.Name;
            salespersonToUpdate.Phone = salesperson.Phone;


            File.WriteAllText(salespersonsFilePath, JsonConvert.SerializeObject(salespersons));
        }
        internal static void Delete(Salesperson salesperson)
        {

            var salespersons = JsonConvert.DeserializeObject<List<Salesperson>>(File.ReadAllText(salespersonsFilePath));


            var salespersonToDelete = salespersons.FirstOrDefault(i => i.SalespersonId == salesperson.SalespersonId);


            salespersons.Remove(salespersonToDelete);


            File.WriteAllText(salespersonsFilePath, JsonConvert.SerializeObject(salespersons));
        }

    }
}
