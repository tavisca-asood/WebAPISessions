using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class SQLServer : IRepository
    {
        static InventoryDatabaseEntities inventory = new InventoryDatabaseEntities();
        static ProductsEntities products = new ProductsEntities();
        public void Save(IRepository product)
        {
            throw new NotImplementedException();
        }
        public static List<ActivityProduct> Activities()
        {
            return inventory.ActivityProducts.ToList();
        }
        public static List<AirProduct> Planes()
        {
            return inventory.AirProducts.ToList();
        }
        public static List<CarProduct> Cars()
        {
            return inventory.CarProducts.ToList();
        }
        public static List<HotelProduct> Hotels()
        {
            return inventory.HotelProducts.ToList();
        }
        public static void SaveActivity(ActivityProduct activity)
        {
            SavedProduct product = new SavedProduct()
            {
                Name = activity.Name,
                Booked = activity.Booked,
                Price = activity.Price,
                TypeOfProduct = "Activity"
            };
            products.SavedProducts.Add(product);
            products.SaveChanges();
        }
    }
}
