using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class AirProduct : IProduct
    {
        public void Book()
        {
            Console.WriteLine("Plane Booked!");
        }

        public void Save()
        {
            Console.WriteLine("Plane Saved!");
        }

        public string TypeOfProduct()
        {
            return "Air";
        }
    }
}
