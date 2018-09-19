using ProductsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductsAPI.Controllers
{
    public class BookedController : ApiController
    {
        // GET: api/Booked
        public IEnumerable<Booked> Get()
        {
            return SQLServer.Instance.GetBooked();
        }
    }
}
