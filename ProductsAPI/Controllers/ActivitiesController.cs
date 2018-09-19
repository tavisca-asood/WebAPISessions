using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using ProductsAPI.Models;

namespace ProductsAPI.Controllers
{
    public class ActivitiesController : ApiController
    {
        // GET: api/Activity
        public List<ActivityProduct> Get()
        {
            return CachingDecorator.Get("Activities").Cast<ActivityProduct>().ToList() ;
        }

        //GET: api/Activity/5
        public ActivityProduct Get(int id)
        {
            return SQLServer.Instance.GetActivities().Find(x => x.ID == id);
        }

        // POST: api/Activity
        public void Post(ActivityProduct activity)
        {
            SQLServer.Instance.AddActivity(activity);
            CachingDecorator.Update("Activities");
        }

        // PUT: api/Activity/5
        public void Put(int id, [FromBody]JObject input)
        {
            string value = input.GetValue("operation").ToString();
            if (value.Equals("book"))
                SQLServer.Instance.BookActivity(id);
            else if (value.Equals("save"))
                SQLServer.Instance.SaveActivity(id);
            CachingDecorator.Update("Activities");
        }

        // DELETE: api/Activity/5
        public void Delete(int id)
        {
        }

        //public List<IProduct> CalculateFare(IEnumerable<IProduct> products)
        //{
        //    IEnumerable<IProduct> activities = products.ToList().ConvertAll(x => new ActivityProduct((ActivityProduct)x));

        //    foreach(ActivityProduct activity in activities)
        //    {
        //        activity.Price += (activity.Price * 10) / 100;
        //    }
        //    return activities.ToList();
        //}
    }
}
