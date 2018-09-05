using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    static class Product
    {
        public static IProduct GetProduct(string type)
        {
            if (type == "Air")
                return new AirProduct();
            else if (type == "Activity")
                return new ActivityProduct();
            else if (type == "Car")
                return new CarProduct();
            else if (type == "Hotel")
                return new HotelProduct();
            throw new Exception();
        }
    }
}
