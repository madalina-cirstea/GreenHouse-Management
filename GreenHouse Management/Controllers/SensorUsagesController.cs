using GreenHouse_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenHouse_Management.Controllers
{
    [Authorize(Roles = "Customer")]
    public class SensorUsagesController : Controller
    {
        private readonly ApplicationDbContext ctx = new ApplicationDbContext();

        // GET: /SensorUsages or /SensorUsages/Index
        public ActionResult Index()
        {
            List<SensorUsage> sensorUsages = ctx.SensorUsages.ToList();
            return View(sensorUsages);
        }

        // GET: /SensorUsages/Add
        public ActionResult Add()
        {
            SensorUsage sensorUsage = new SensorUsage();
            return View(sensorUsage);
        }

        // POST: /SensorUsages/Create
        [HttpPost]
        public ActionResult Create(SensorUsage s)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ctx.SensorUsages.Add(s);
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

        // GET: /SensorUsages/Edit/id
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                SensorUsage sensorUsage = ctx.SensorUsages.Find(id);
                if (sensorUsage == null)
                {
                    return HttpNotFound("Couldn't find the sensorUsage with id " + id.ToString());
                }
                return View(sensorUsage);
            }
            return HttpNotFound("Missing sensorUsage id parameter!");
        }

        // PUT: /SensorUsages/Update
        [HttpPut]
        public ActionResult Update(SensorUsage s)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SensorUsage sensorUsage = ctx.SensorUsages.Single(a => a.SensorUsageId == s.SensorUsageId);
                    if (TryUpdateModel(sensorUsage))
                    {
                        sensorUsage.RecordedType = s.RecordedType;
                        sensorUsage.MeasurementUnit = s.MeasurementUnit;
                        sensorUsage.Description = s.Description;
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

        // DELETE: /SensorUsages/Delete/id
        [HttpDelete]
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                SensorUsage sensorUsage = ctx.SensorUsages.Find(id);
                if (sensorUsage != null)
                {
                    ctx.SensorUsages.Remove(sensorUsage);
                    ctx.SaveChanges();
                    return RedirectToAction("Index");
                }
                return HttpNotFound("Couldn't find the sensorUsage with id " + id.ToString());
            }
            return HttpNotFound("Missing sensorUsage id parameter!");
        }
    }
}