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
    public class ActivitiesController : ApiController
    {
        // GET: api/Activity
        public IEnumerable<ActivityProduct> Get()
        {
            return SQLServer.Instance.GetActivities();
        }

        // GET: api/Activity/5
        public ActivityProduct Get(int id)
        {
            return SQLServer.Instance.GetActivities().Find(x=>x.ID==id);
        }

        // POST: api/Activity
        public void Post(ActivityProduct activity)
        {
            SQLServer.Instance.AddActivity(activity);
        }

        // PUT: api/Activity/5
        public void Put(int id, [FromBody]JObject input)
        {
            string value = input.GetValue("operation").ToString();
            if (value.Equals("book"))
                SQLServer.Instance.BookActivity(id);
            else if (value.Equals("save"))
                SQLServer.Instance.SaveActivity(id);
        }

        // DELETE: api/Activity/5
        public void Delete(int id)
        {
        }
    }
}
