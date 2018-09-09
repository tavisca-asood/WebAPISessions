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
    public class PlanesController : ApiController
    {
        // GET: api/Air
        public IEnumerable<AirProduct> Get()
        {
            return SQLServer.Instance.GetPlanes().ToList();
        }

        // GET: api/Air/5
        public AirProduct Get(int id)
        {
            return SQLServer.Instance.GetPlanes().ToList().Find(x => x.ID == id);
        }

        // POST: api/Air
        public void Post(AirProduct plane)
        {
            SQLServer.Instance.AddPlane(plane);
        }

        // PUT: api/Air/5
        public void Put(int id, [FromBody]JObject input)
        {
            string value = input.GetValue("operation").ToString();
            if (value.Equals("book"))
                SQLServer.Instance.BookPlane(id);
            else if (value.Equals("save"))
                SQLServer.Instance.SavePlane(id);
        }

        // DELETE: api/Air/5
        public void Delete(int id)
        {
        }
    }
}
