using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart
{
    class CartOperations : ICartOperations
    {
        List<CartItem> _items = new List<CartItem>();

        public void AddItem(CartItem item)
        {
            if (_items.FindIndex(x => x.Id == item.Id) != -1)
            {
                _items.Find(x => x.Id == item.Id).Quantity += item.Quantity;
                return;
            }
                _items.Add(item);
        }

        public void ClearCart()
        {
            _items.Clear();
        }

        public void RemoveItem(int ItemId)
        {
            _items.Remove(_items.Find(x => x.Id == ItemId));
        }

        public void ShowCart()
        {
            foreach (CartItem item in _items)
                Console.WriteLine("Id = {0}\tName = {1}\tPrice = {2}\tQuantity = {3}", item.Id, item.Name, item.Price, item.Quantity);
        }

        public double TotalAmount()
        {
            return _items.Sum(item => item.Price * item.Quantity);
        }

        public void Checkout()
        {
            Checkout checkout = new Checkout();
            ClearCart();
        }
    }
}
