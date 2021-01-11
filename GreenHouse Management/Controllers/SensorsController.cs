using GreenHouse_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenHouse_Management.Controllers
{
    [AllowAnonymous]
    //[Authorize(Roles = "Customer")]
    public class SensorsController : Controller
    {
        private readonly ApplicationDbContext ctx = new ApplicationDbContext();

        // GET: /Sensors or /Sensors/Index
        public ActionResult Index()
        {
            List<Sensor> sensors = ctx.Sensors.ToList();
            return View(sensors);
        }

        // GET: /Sensors/Add
        public ActionResult Add()
        {
            Sensor sensor = new Sensor();
            return View(sensor);
        }

        // POST: /Sensors/Create
        [HttpPost]
        public ActionResult Create(Sensor s)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ctx.Sensors.Add(s);
                    ctx.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View("Add", s);
            }
            catch (Exception e)
            {
                return View("Add", s);
            }
        }

        // GET: /Sensors/AddUsages/sensorId
        public ActionResult AddUsages(int? sensorId)
        {
            if (sensorId.HasValue)
            {
                ViewBag.sensorId = sensorId;
                List<SensorUsage> sensorUsages = ctx.SensorUsages.ToList();
                return View(sensorUsages);
            }
            return HttpNotFound("Missing sensor id parameter!");
        }

        // GET: /Sensors/AddUsage/sensorId&usageId
        public ActionResult AddUsage(int? sensorId, int? usageId)
        {
            if (sensorId.HasValue && usageId.HasValue)
            {
                Sensor sensor = ctx.Sensors.Find(sensorId);
                if (sensor == null)
                    return HttpNotFound("Couldn't find the sensor with id " + sensorId.ToString());

                SensorUsage usage = ctx.SensorUsages.Find(usageId);
                if (usage == null)
                    return HttpNotFound("Couldn't find the usage with id " + usageId.ToString());

                sensor.SensorUsages.Add(usage);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }

            if (!usageId.HasValue)
                return HttpNotFound("Missing usage id parameter!");

            if (!sensorId.HasValue)
                return HttpNotFound("Missing sensor id parameter!");

            return HttpNotFound("Missing parameters!");
        }

        // GET: /Sensors/RemoveUsages/sensorId
        public ActionResult RemoveUsages(int? sensorId)
        {
            if (sensorId.HasValue)
            {
                ViewBag.sensorId = sensorId;
                List<SensorUsage> sensorUsages = ctx.SensorUsages.ToList();
                return View(sensorUsages);
            }
            return HttpNotFound("Missing sensor id parameter!");
        }

        // GET: /Sensors/RemoveUsage/sensorId&usageId
        public ActionResult RemoveUsage(int? sensorId, int? usageId)
        {
            if (sensorId.HasValue && usageId.HasValue)
            {
                Sensor sensor = ctx.Sensors.Find(sensorId);
                if (sensor == null)
                    return HttpNotFound("Couldn't find the sensor with id " + sensorId.ToString());

                SensorUsage usage = ctx.SensorUsages.Find(usageId);
                if (usage == null)
                    return HttpNotFound("Couldn't find the usage with id " + usageId.ToString());

                sensor.SensorUsages.Remove(usage);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }

            if (!usageId.HasValue)
                return HttpNotFound("Missing usage id parameter!");

            if (!sensorId.HasValue)
                return HttpNotFound("Missing sensor id parameter!");

            return HttpNotFound("Missing parameters!");
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
            try
            {
                if (ModelState.IsValid)
                {
                    Sensor sensor = ctx.Sensors.Single(a => a.SensorId == s.SensorId);
                    if (TryUpdateModel(sensor))
                    {
                        sensor.Name = s.Name;
                        sensor.Model = s.Model;
                        sensor.Value = s.Value;
                        sensor.OperatingState = s.OperatingState;
                        ctx.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View("Edit", s);
            }
            catch (Exception e)
            {
                return View("Edit", s);
            }
        }

        // DELETE: /Sensors/Delete/id
        [HttpDelete]
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                Sensor sensor = ctx.Sensors.Find(id);
                if (sensor != null)
                {
                    ctx.Sensors.Remove(sensor);
                    ctx.SaveChanges();
                    return RedirectToAction("Index");
                }
                return HttpNotFound("Couldn't find the sensor with id " + id.ToString());
            }
            return HttpNotFound("Missing sensor id parameter!");
        }
    }
}