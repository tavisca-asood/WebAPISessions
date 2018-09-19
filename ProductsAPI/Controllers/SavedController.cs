using ProductsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductsAPI.Controllers
{
    public class SavedController : ApiController
    {
        // GET: api/Saved
        public IEnumerable<Saved> Get()
        {
            return SQLServer.Instance.GetSaved();
        }
    }
}
