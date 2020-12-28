using GreenHouse_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenHouse_Management.Controllers
{
    public class SensorsController : Controller
    {
        private ApplicationDbContext ctx = new ApplicationDbContext();

        // GET: /Sensors or /Sensors/Index
        public ActionResult Index()
        {
            List<Sensor> sensors = ctx.Sensors.ToList();
            return View(sensors);
        }

        // GET: /Sensors/Add
        public ActionResult Add()
        {
            return View();
        }

        // POST: /Sensors/Create
        [HttpPost]
        public ActionResult Create(Sensor s)
        {
            // verifica daca s-a realizat corect fenomenul de MODEL BINDING
            // - daca nu s-au incalcat in timpul procesului de binding reguli de validare 
            if (ModelState.IsValid)
            {
                ctx.Sensors.Add(s);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Add");
        }

        // GET: /Sensors/Edit/id
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                Sensor sensor = ctx.Sensors.Find(id);
                if (sensor == null)
                {
                    return HttpNotFound("Couldn't find the sensor with id " + id.ToString());
                }
                return View(sensor);
            }
            return HttpNotFound("Missing sensor id parameter!");
        }

        // PUT: /Sensors/Update
        [HttpPut]
        public ActionResult Update(Sensor s)
        {
            if (ModelState.IsValid)
            {
                Sensor sensor = ctx.Sensors.Single(a => a.SensorId == s.SensorId);
                if (TryUpdateModel(sensor))
                {
                    sensor.Name = s.Name;
                    sensor.Model = s.Model;
                    sensor.OperatingState = s.OperatingState;
                    ctx.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}