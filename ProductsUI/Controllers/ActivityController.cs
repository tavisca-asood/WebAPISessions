using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProductsUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProductsUI.Controllers
{
    public class ActivityController : Controller
    {
        string _url = "http://localhost:49348/";
        // GET: Activity
        public ActionResult Index()
        {
            List<ActivityProduct> activities = GetActivities();
            return View("~/Views/Activity/Activities.cshtml", activities);
        }

        public ActionResult Book(int id)
        {
            BookActivity(id);
            return Index();
        }

        public ActionResult Save(int id)
        {
            SaveActivity(id);
            return Index();
        }

        // GET: Activity/Create
        public ActionResult Add()
        {
            return View("~/Views/Activity/AddActivity.cshtml");
        }

        // POST: Activity/Create
        [HttpPost]
        public ActionResult Add(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                PostActivity(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("~/Views/Activity/AddActivity.cshtml");
            }
        }

        private List<ActivityProduct> GetActivities()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("/api/Activities").Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsondata = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<ActivityProduct>>(jsondata);
                }
                return null;
            }
        }
        private void PostActivity(FormCollection activity)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new FormUrlEncodedContent(activity.AllKeys.ToDictionary(k => k, v => activity[v]));

                HttpResponseMessage response = client.PostAsync("/api/Activities", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsondata = response.Content.ReadAsStringAsync().Result;
                }
            }
        }

        private void BookActivity(int id)
        {
            using (var client = new HttpClient())
            {
                Dictionary<string, string> operation = new Dictionary<string, string>();
                operation.Add("operation", "book");
                client.BaseAddress = new Uri(_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new FormUrlEncodedContent(operation);

                HttpResponseMessage response = client.PutAsync("/api/Activities/" + id, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsondata = response.Content.ReadAsStringAsync().Result;
                }
            }
        }
        private void SaveActivity(int id)
        {
            using (var client = new HttpClient())
            {
                Dictionary<string, string> operation = new Dictionary<string, string>();
                operation.Add("operation", "save");
                client.BaseAddress = new Uri(_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new FormUrlEncodedContent(operation);

                HttpResponseMessage response = client.PutAsync("/api/Activities/" + id, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsondata = response.Content.ReadAsStringAsync().Result;
                }
            }
        }
    }
}