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
    public class SavedController : Controller
    {
        // GET: Saved
        private string _url = ConfigurationManager.AppSettings["apiUrl"];
        // GET: Booked
        public ActionResult Index()
        {
            List<Saved> booked = GetSaved();
            return View("~/Views/Saved.cshtml", booked);
        }
        private List<Saved> GetSaved()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("/api/Saved").Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsondata = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<Saved>>(jsondata);
                }
                return null;
            }
        }
    }
}