using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart
{
    class Cart : ICart
    {
        List<CartItem> items = new List<CartItem>();

        public void AddItemToCart(CartItem item)
        {
            items.Add(item);
        }

        public void ClearCart()
        {
            items.Clear();
        }

        public void RemoveItemFromCart(int ItemId)
        {
            items.Remove(items.Find(x => x.Id == ItemId));
        }

        public void ShowCart()
        {
            throw new NotImplementedException();
        }

        public double TotalAmount()
        {
            return items.Sum(item => item.Price);
        }

        public void Checkout()
        {
            Checkout checkout = new Checkout();
            ClearCart();
        }
    }
}
