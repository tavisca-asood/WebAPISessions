using Newtonsoft.Json;
using ProductsUI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace ProductsUI.Controllers
{
    public class AirController : Controller
    {
        private string _url = ConfigurationManager.AppSettings["apiUrl"];
        // GET: Air
        public ActionResult Index()
        { 
            List<AirProduct> planes = GetPlanes();
            if (planes == null)
                RedirectToAction("Index", "User");
            return View("~/Views/Air/planes.cshtml", planes);
        }
        
        public ActionResult Book(int id)
        {
            BookPlane(id);
            return Index();
        }
        
        public ActionResult Save(int id)
        {
            SavePlane(id);
            return Index();
        }

        public ActionResult Add()
        {
            return View("~/Views/Air/AddPlane.cshtml");
        }

        [HttpPost]
        public ActionResult Add(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                PostPlane(collection);
            }
            catch
            {
            }
            return RedirectToAction("Add");
        }

        private List<AirProduct> GetPlanes()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("/api/Planes").Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsondata = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<AirProduct>>(jsondata);
                }
                return null;
            }
        }

        private void PostPlane(FormCollection plane)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new FormUrlEncodedContent(plane.AllKeys.ToDictionary(k => k, v => plane[v]));

                HttpResponseMessage response = client.PostAsync("/api/Planes", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsondata = response.Content.ReadAsStringAsync().Result;
                }
            }
        }

        private void BookPlane(int id)
        {
            using (var client = new HttpClient())
            {
                Dictionary<string, string> operation = new Dictionary<string, string>();
                operation.Add("operation", "book");
                client.BaseAddress = new Uri(_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new FormUrlEncodedContent(operation);

                HttpResponseMessage response = client.PutAsync("/api/Planes/" + id, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsondata = response.Content.ReadAsStringAsync().Result;
                }
            }
        }
        private void SavePlane(int id)
        {
            using (var client = new HttpClient())
            {
                Dictionary<string, string> operation = new Dictionary<string, string>();
                operation.Add("operation", "save");
                client.BaseAddress = new Uri(_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new FormUrlEncodedContent(operation);

                HttpResponseMessage response = client.PutAsync("/api/Planes/" + id, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsondata = response.Content.ReadAsStringAsync().Result;
                }
            }
        }
    }
}
