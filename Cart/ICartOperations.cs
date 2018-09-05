using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart
{
    interface ICartOperations
    {
        void AddItem(CartItem item);
        void RemoveItem(int ItemId);
        double TotalAmount();
        void ShowCart();
        void ClearCart();
        void Checkout();
    }
}
