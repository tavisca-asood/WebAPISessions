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
    public class HotelsController : ApiController
    {
        // GET: api/Hotel
        public IEnumerable<HotelProduct> Get()
        {
            return SQLServer.Instance.GetHotels().ToList();
        }

        // GET: api/Hotel/5
        public HotelProduct Get(int id)
        {
            return SQLServer.Instance.GetHotels().ToList().Find(x => x.ID == id);
        }

        // POST: api/Hotel
        public void Post(HotelProduct hotel)
        {
            SQLServer.Instance.AddHotel(hotel);
        }

        // PUT: api/Hotel/5
        public void Put(int id, [FromBody]JObject input)
        {
            string value = input.GetValue("operation").ToString();
            if (value.Equals("book"))
                SQLServer.Instance.BookHotel(id);
            else if (value.Equals("save"))
                SQLServer.Instance.SaveHotel(id);
        }

        // DELETE: api/Hotel/5
        public void Delete(int id)
        {
        }
    }
}
