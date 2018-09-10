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
    public class BookedController : Controller
    {
        private string _url = ConfigurationManager.AppSettings["apiUrl"];
        // GET: Booked
        public ActionResult Index()
        {
            List<Booked> booked=GetBooked();
            return View("~/Views/Booked.cshtml",booked);
        }
        private List<Booked> GetBooked()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("/api/Booked").Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsondata = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<Booked>>(jsondata);
                }
                return null;
            }
        }
    }
}
