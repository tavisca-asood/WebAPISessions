using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart
{
    interface ICart
    {
        void AddItemToCart(CartItem item);
        void RemoveItemFromCart(int ItemId);
        double TotalAmount();
        void ShowCart();
        void ClearCart();
        void Checkout();
    }
}
