using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class HotelProduct : IProduct
    {
        public void Book()
        {
            Console.WriteLine("Hotel Booked!");
        }

        public void Save()
        {
            Console.WriteLine("Hotel Saved!");
        }

        public string TypeOfProduct()
        {
            return "Hotel";
        }
    }
}
