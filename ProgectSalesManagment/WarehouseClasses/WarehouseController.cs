using Newtonsoft.Json;
using ProgectSalesManagment.CustomerClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProgectSalesManagment.WarehouseClasses.WarehouseController;

namespace ProgectSalesManagment.WarehouseClasses
{
    internal class WarehouseController
    {
        
        
            private static readonly string warehousesFilePath = "WarehousesFile.text";

            internal static int GetID()
            {
            if (File.Exists(warehousesFilePath))
            {

                if (File.ReadAllText(warehousesFilePath) == " ")
                {
                    return 1;
                }

                else { var JsonContent = File.ReadAllText(warehousesFilePath);
                    var warehouses = JsonConvert.DeserializeObject<List<Warehouse>>(JsonContent);
                    var warehouseId = warehouses[warehouses.Count - 1].WarehouseId;
                    return warehouseId + 1;
                }
            }
            else
            {
                File.WriteAllText(warehousesFilePath," ");
                return 1;
            }

            }

            internal static List<Warehouse> GetAll()
            {
                var warehouses = new List<Warehouse>();
                if (File.ReadAllText(warehousesFilePath) != " ")
                {
                    warehouses = JsonConvert.DeserializeObject<List<Warehouse>>(File.ReadAllText(warehousesFilePath));


                    return warehouses;
                }
                else { return warehouses; }
            }

            internal static Warehouse GetByID(int warehouseId)
            {

                var warehouses = JsonConvert.DeserializeObject<List<Warehouse>>(File.ReadAllText(warehousesFilePath));


                var warehouse = warehouses.FirstOrDefault(i => i.WarehouseId == warehouseId);


                return warehouse;
            }

            internal static void AddNew(Warehouse warehouse)
            {
                List<Warehouse> warehouses = new List<Warehouse>();
                if (File.ReadAllText(warehousesFilePath) != " ")
                {

                    warehouses = JsonConvert.DeserializeObject<List<Warehouse>>(File.ReadAllText(warehousesFilePath));
                }

                warehouses.Add(warehouse);


                File.WriteAllText(warehousesFilePath, JsonConvert.SerializeObject(warehouses));
            }

            internal static void Update(Warehouse warehouse)
            {

                var warehouses = JsonConvert.DeserializeObject<List<Warehouse>>(File.ReadAllText(warehousesFilePath));


                var warehouseToUpdate = warehouses.FirstOrDefault(i => i.WarehouseId == warehouse.WarehouseId);


                warehouseToUpdate.WarehouseId = warehouse.WarehouseId;
                warehouseToUpdate.Address = warehouse.Address;


                File.WriteAllText(warehousesFilePath, JsonConvert.SerializeObject(warehouses));
            }

            internal static void Delete(Warehouse warehouse)
            {

                var warehouses = JsonConvert.DeserializeObject<List<Warehouse>>(File.ReadAllText(warehousesFilePath));


                var warehouseToDelete = warehouses.FirstOrDefault(i => i.WarehouseId == warehouse.WarehouseId);


                warehouses.Remove(warehouseToDelete);


                File.WriteAllText(warehousesFilePath, JsonConvert.SerializeObject(warehouses));
            }
        
    }
}
