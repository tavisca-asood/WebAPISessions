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
            string desc = Console.ReadLine();
            IProduct product = Product.GetProduct(desc);
            Console.WriteLine(product.TypeOfProduct());
            product.Book();
            product.Save();
            Console.ReadKey();
        }
    }
}
