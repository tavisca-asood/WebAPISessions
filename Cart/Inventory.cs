using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart
{
    class Inventory
    {
        static List<InventoryItem> items = new List<InventoryItem>();
        public void AddItem()
        {
            int id;
            double price;
            Console.WriteLine("Enter item Id");
            int.TryParse(Console.ReadLine(), out id);
            Console.WriteLine("Enter item name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter item price");
            double.TryParse(Console.ReadLine(), out price);
            items.Add(new InventoryItem()
            {
                Id = id,
                Name = name,
                Price = price
            });
        }
        public void AddItem(InventoryItem item)
        {
            items.Add(item);
        }

        public void DisplayItems()
        {
            foreach (InventoryItem item in items)
                Console.WriteLine("Id = {0}\tName = {1}\tPrice = {2}", item.Id, item.Name, item.Price);
        }

        public InventoryItem GetItem(int id)
        {
            return items.Find(x => x.Id == id);
        }
    }
}
