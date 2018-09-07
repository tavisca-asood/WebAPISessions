using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            int option;
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Enter 'Activity' for Activity Product\nEnter 'Air' for Air Product\nEnter 'Car' for Car Product\nEnter 'Hotel' for Hotel Product\n\t*Default is Hotel");
                string productType = Console.ReadLine();
                IProduct selected =  ProductFactory.GetProductType(productType);
                Product product = new Product(selected);
                product.DisplayList();
                flag = false;
            }
            Console.ReadKey();
        }
    }
}
