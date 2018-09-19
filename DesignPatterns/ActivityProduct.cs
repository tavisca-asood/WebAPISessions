using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class ActivityProduct : IProduct
    {
        public void Book()
        {
            Console.WriteLine("Activity Booked!");
        }

        public void Save()
        {
            Console.WriteLine("Activity Saved!");
        }

        public string TypeOfProduct()
        {
            return "Activity";
        }
    }
}
