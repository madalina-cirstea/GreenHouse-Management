using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenHouse_Management.Controllers
{
    public class SensorsController : Controller
    {
        // GET: Sensors
        public ActionResult Index()
        {
            return View();
        }
    }
}