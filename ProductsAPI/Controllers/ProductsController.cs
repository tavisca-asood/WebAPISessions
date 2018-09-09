using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using ProductsAPI.Models;

namespace ProductsAPI.Controllers
{
    public class ProductsController : ApiController
    {
        static InventoryDatabaseEntities products = new InventoryDatabaseEntities();
        string current = string.Empty;
        // GET: api/Products
        public IEnumerable<IProduct> Get()
        {
            return products.HotelProducts.ToList();
        }

        // GET: api/Products/5
        public IEnumerable<IProduct> Get(int id)
        {
            switch(id)
            {
                case 1:
                    return products.ActivityProducts.ToList();
                case 2:
                    return products.AirProducts.ToList();
                case 3:
                    return products.CarProducts.ToList();
                case 4:
                    return products.HotelProducts.ToList();
                default:
                    return products.HotelProducts.ToList();
            }
        }

        // POST: api/Products
        public void Post(int id,[FromBody]JObject x)
        {
            switch(id)
            {
                case 1:
                    products.ActivityProducts.Add(x.ToObject<ActivityProduct>());
                    current = "Activity";
                    break;
                case 2:
                    products.AirProducts.Add(x.ToObject<AirProduct>());
                    current = "Air";
                    break;
                case 3:
                    products.CarProducts.Add(x.ToObject<CarProduct>());
                    current = "Car";
                    break;
                case 4:
                    products.HotelProducts.Add(x.ToObject<HotelProduct>());
                    current = "Hotel";
                    break;
                default:
                    current = "Hotel";
                    break;
            }
            products.SaveChanges();
        }

        // PUT: api/Products/5
        public void Put([FromUri]int id,JObject data)
        {
            //string parameter = data.GetValue("Parameter").ToString();
            //if (current == string.Empty)
            //    return;
            //switch(current)
            //{
            //    case "Activity":
            //        ActivityProduct activity = products.ActivityProducts.ToList().Find(x => x.ID == id);
            //        if (activity == null)
            //            return;
            //        if (value == 1)
            //            activity.Book();
            //        else
            //            activity.Save();
            //            products.SaveChanges();
            //        break;
            //    case "Air":
            //        AirProduct plane = products.AirProducts.ToList().Find(x => x.ID == id);
            //        if (plane == null)
            //            return;
            //        if (value == 1)
            //            plane.Book();
            //        else
            //            plane.Save();
            //        products.SaveChanges();
            //        break;
            //    case "Car":
            //        CarProduct car= products.CarProducts.ToList().Find(x => x.ID == id);
            //        if (car == null)
            //            return;
            //        if (value == 1)
            //            car.Book();
            //        else
            //            car.Save();
            //        products.SaveChanges();
            //        break;
            //    case "Hotel":
            //        HotelProduct hotel = products.HotelProducts.ToList().Find(x => x.ID == id);
            //        if (hotel == null)
            //            return;
            //        if (value == 1)
            //            hotel.Book();
            //        else
            //            hotel.Save();
            //        products.SaveChanges();
            //        break;
            //    default:
            //        return;
            //}
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
