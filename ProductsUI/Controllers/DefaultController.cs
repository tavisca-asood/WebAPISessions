using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductsUI.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View("~/Views/Default.cshtml");
        }

        // GET: Default/Details/5
        public ActionResult Admin()
        {
            return RedirectToAction("Index", "Admin");
        }

        // GET: Default/Create
        public ActionResult User()
        {
            return RedirectToAction("Index", "User");
        }
    }
}
