using Newtonsoft.Json;
using ProductsUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace ProductsUI.Controllers
{
    public class CarController : Controller
    {
        // GET: Car
        private string _url = "http://localhost:49348/";
        // GET: Air
        public ActionResult Index()
        {
            List<CarProduct> cars = GetCars();
            return View("~/Views/Car/Cars.cshtml", cars);
        }

        public ActionResult Book(int id)
        {
            BookCar(id);
            return Index();
        }

        public ActionResult Save(int id)
        {
            SaveCar(id);
            return Index();
        }

        public ActionResult Add()
        {
            return View("~/Views/Car/AddCar.cshtml");
        }

        [HttpPost]
        public ActionResult Add(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                PostCar(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("~/Views/Car/AddCar.cshtml");
            }
        }

        private List<CarProduct> GetCars()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("/api/Cars").Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsondata = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<CarProduct>>(jsondata);
                }
                return null;
            }
        }

        private void PostCar(FormCollection car)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new FormUrlEncodedContent(car.AllKeys.ToDictionary(k => k, v => car[v]));

                HttpResponseMessage response = client.PostAsync("/api/Cars", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsondata = response.Content.ReadAsStringAsync().Result;
                }
            }
        }

        private void BookCar(int id)
        {
            using (var client = new HttpClient())
            {
                Dictionary<string, string> operation = new Dictionary<string, string>();
                operation.Add("operation", "book");
                client.BaseAddress = new Uri(_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new FormUrlEncodedContent(operation);

                HttpResponseMessage response = client.PutAsync("/api/Cars/" + id, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsondata = response.Content.ReadAsStringAsync().Result;
                }
            }
        }
        private void SaveCar(int id)
        {
            using (var client = new HttpClient())
            {
                Dictionary<string, string> operation = new Dictionary<string, string>();
                operation.Add("operation", "save");
                client.BaseAddress = new Uri(_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new FormUrlEncodedContent(operation);

                HttpResponseMessage response = client.PutAsync("/api/Cars/" + id, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsondata = response.Content.ReadAsStringAsync().Result;
                }
            }
        }
    }
}
