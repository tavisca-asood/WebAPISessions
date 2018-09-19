//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Web;
//using ProductsAPI.Models;

//namespace ProductsAPI
//{
//    public class ProductFactory
//    {
//        InventoryDatabaseEntities inventory = new InventoryDatabaseEntities();
//        public static IEnumerable<IProduct> GetProductType(int id)
//        {
//            string productType;
//            switch(id)
//            {
//                case 1:
//                    productType = "ActivityProduct";
//                    break;
//                case 2:
//                    productType = "AirProduct";
//                    break;
//                case 3:
//                    productType = "CarProduct";
//                    break;
//                case 4:
//                    productType = "HotelProduct";
//                    break;
//                default:
//                    productType = "HotelProduct";
//                    break;
//            }
//            Assembly assembly = Assembly.GetExecutingAssembly();
//            var product = assembly.GetTypes().FirstOrDefault(t => t.Name == productType);
//            try
//            {
//                return (IProduct)Activator.CreateInstance(product);
//            }
//            catch (ArgumentNullException exception) { }
//            return new ;
//        }
//    }
//}