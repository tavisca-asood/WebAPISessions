using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class CarProduct : IProduct
    {
        public void Book()
        {
            Console.WriteLine("Car Booked!");
        }

        public void Save()
        {
            Console.WriteLine("Car Saved!");
        }

        public string TypeOfProduct()
        {
            return "Car";
        }
    }
}
