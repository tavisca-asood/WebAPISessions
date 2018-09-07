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
    }
}
