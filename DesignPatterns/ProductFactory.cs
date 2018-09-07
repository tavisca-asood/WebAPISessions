using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class ProductFactory
    {
        public static IProduct GetProductType(string productType)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var product = assembly.GetTypes().FirstOrDefault(t => t.Name == productType+"Product");
            try
            {
                return (IProduct)Activator.CreateInstance(product);
            }
            catch (ArgumentNullException exception) { }
            return new HotelProduct();
        }
    }
}
