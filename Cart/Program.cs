using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart
{
    class Program
    {
        static void AddItemsToInventory(Inventory inventory)
        {
            inventory.AddItem(
                new InventoryItem()
                {
                    Id = 1,
                    Name = "Milk",
                    Price = 25
                }
                );
            inventory.AddItem(
                new InventoryItem()
                {
                    Id = 2,
                    Name = "Sugar",
                    Price = 40
                }
                );
            inventory.AddItem(
                new InventoryItem()
                {
                    Id = 3,
                    Name = "Banana",
                    Price = 5
                }
                );
        }
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            AddItemsToInventory(inventory);
            bool flag = true;
            int selectedOption;
            CartOperations cart = new CartOperations();
            int id;
            while(flag)
            {
                Console.WriteLine("Enter 1 to show cart\nEnter 2 to add item to cart\nEnter 3 to remove item from card\nEnter 4 to clear cart\nEnter 5 to print total amount\nEnter 6 to exit");
                int.TryParse(Console.ReadLine(), out selectedOption);
                switch(selectedOption)
                {
                    case 1:
                        cart.ShowCart();
                        break;
                    case 2:
                        inventory.DisplayItems();
                        Console.WriteLine("Enter item id");
                        int.TryParse(Console.ReadLine(), out id);
                        InventoryItem inventoryItem = inventory.GetItem(id);
                        if (inventoryItem == null)
                        {
                            Console.WriteLine("Please enter a valid Id");
                            break;
                        }
                        Console.WriteLine("Enter quantity");
                        int quantity;
                        int.TryParse(Console.ReadLine(), out quantity);
                        if(quantity<1)
                        {
                            Console.WriteLine("Please enter a valid quantity");
                            break;
                        }
                        CartItem item = new CartItem();
                        item.Id = inventoryItem.Id;
                        item.Name = inventoryItem.Name;
                        item.Price = inventoryItem.Price;
                        item.Quantity = quantity;
                        cart.AddItem(item);
                        break;
                    case 3:
                        Console.WriteLine("Enter item id to remove");
                        int.TryParse(Console.ReadLine(), out id);
                        cart.RemoveItem(id);
                        break;
                    case 4:
                        cart.ClearCart();
                        break;
                    case 5:
                        Console.WriteLine(cart.TotalAmount());
                        break;
                    case 6:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option");
                        break;
                }
            }
        }
    }
}
