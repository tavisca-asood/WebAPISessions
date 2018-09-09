using Newtonsoft.Json.Linq;
using ProductsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductsAPI.Controllers
{
    public class CarsController : ApiController
    {
        // GET: api/Car
        public IEnumerable<CarProduct> Get()
        {
            return SQLServer.Instance.GetCars().ToList();
        }

        // GET: api/Car/5
        public CarProduct Get(int id)
        {
            return SQLServer.Instance.GetCars().ToList().Find(x => x.ID == id);
        }

        // POST: api/Car
        public void Post(CarProduct car)
        {
            SQLServer.Instance.AddCar(car);
        }

        // PUT: api/Car/5
        public void Put(int id, [FromBody]JObject input)
        {
            string value = input.GetValue("operation").ToString();
            if (value.Equals("book"))
                SQLServer.Instance.BookCar(id);
            else if (value.Equals("save"))
                SQLServer.Instance.SaveCar(id);
        }

        // DELETE: api/Car/5
        public void Delete(int id)
        {
        }
    }
}
