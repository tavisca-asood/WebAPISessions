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
    public class HotelController : Controller
    {
        // GET: Hotel
        private string _url = "http://localhost:49348/";
        // GET: Air
        public ActionResult Index()
        {
            List<HotelProduct> hotels = GetHotels();
            return View("~/Views/Hotel/Hotels.cshtml", hotels);
        }

        public ActionResult Book(int id)
        {
            BookHotel(id);
            return Index();
        }

        public ActionResult Save(int id)
        {
            SaveHotel(id);
            return Index();
        }

        public ActionResult Add()
        {
            return View("~/Views/Hotel/AddHotel.cshtml");
        }

        [HttpPost]
        public ActionResult Add(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                PostHotel(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("~/Views/Hotel/AddHotel.cshtml");
            }
        }

        private List<HotelProduct> GetHotels()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("/api/Hotels").Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsondata = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<HotelProduct>>(jsondata);
                }
                return null;
            }
        }

        private void PostHotel(FormCollection hotel)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new FormUrlEncodedContent(hotel.AllKeys.ToDictionary(k => k, v => hotel[v]));

                HttpResponseMessage response = client.PostAsync("/api/Hotels", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsondata = response.Content.ReadAsStringAsync().Result;
                }
            }
        }

        private void BookHotel(int id)
        {
            using (var client = new HttpClient())
            {
                Dictionary<string, string> operation = new Dictionary<string, string>();
                operation.Add("operation", "book");
                client.BaseAddress = new Uri(_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new FormUrlEncodedContent(operation);

                HttpResponseMessage response = client.PutAsync("/api/Hotels/" + id, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsondata = response.Content.ReadAsStringAsync().Result;
                }
            }
        }
        private void SaveHotel(int id)
        {
            using (var client = new HttpClient())
            {
                Dictionary<string, string> operation = new Dictionary<string, string>();
                operation.Add("operation", "save");
                client.BaseAddress = new Uri(_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new FormUrlEncodedContent(operation);

                HttpResponseMessage response = client.PutAsync("/api/Hotels/" + id, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsondata = response.Content.ReadAsStringAsync().Result;
                }
            }
        }
    }
}
