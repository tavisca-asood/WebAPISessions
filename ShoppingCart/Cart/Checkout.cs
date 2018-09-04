using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart
{
    enum PaymentMode
    {
        Card,
        OnlineBanking,
        UPI,
        Cash
    }
    class Checkout : ICheckout
    {
        public void GetPaymentMode() { }
        public void GetAddress() { }
    }
}
