using GreenHouse_Management.Models;
using GreenHouse_Management.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenHouse_Management.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext ctx = new ApplicationDbContext();

        [NonAction]
        public IEnumerable<SelectListItem> SelectAllShops()
        {
            var selectList = new List<SelectListItem>();

            foreach (var shop in ctx.Shops.ToList())
            {
                selectList.Add(new SelectListItem
                {
                    Value = shop.ShopId.ToString(),
                    Text = shop.Name
                });
            }

            return selectList;
        }

        // GET: /Employees or /Employees/Index
        public ActionResult Index()
        {
            List<Employee> employees = ctx.Employees.ToList();
            return View(employees);
        }

        // GET: /Employees/Add
        public ActionResult Add()
        {
            EmployeeShopsViewModel esm = new EmployeeShopsViewModel
            {
                ShopsList = SelectAllShops()
            };

            return View(esm);
        }

        // POST: /Employees/Create
        [HttpPost]
        public ActionResult Create(EmployeeShopsViewModel esm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int shopId = Int32.Parse(esm.ShopId);
                    Shop shop = ctx.Shops.Find(shopId);
                    Employee emp = new Employee
                    {
                        ShopId = shopId,
                        Shop = shop,
                        Name = esm.Name,
                        EIN = esm.EIN,
                        Address = esm.Address
                    };

                    if (TryValidateModel(emp))
                    {
                        ctx.Employees.Add(emp);
                        ctx.SaveChanges();
                    }

                    return RedirectToAction("Index");
                }

                esm.ShopsList = SelectAllShops();
                return View("Add", esm);
            }
            catch (Exception e)
            {
                esm.ShopsList = SelectAllShops();
                return View("Add", esm);
            }
        }

        // GET: /Employees/Details/id
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Employee employee = ctx.Employees.Find(id);
                if (employee == null)
                {
                    return HttpNotFound("Couldn't find the employee with id " + id.ToString());
                }
                return View(employee);
            }
            return HttpNotFound("Missing employee id parameter!");
        }

        // GET: /Employees/Edit/id
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                Employee employee = ctx.Employees.Find(id);
                if (employee == null)
                {
                    return HttpNotFound("Couldn't find the employee with id " + id.ToString());
                }
                return View(employee);
            }
            return HttpNotFound("Missing employee id parameter!");
        }

        // PUT: /Employees/Update
        [HttpPut]
        public ActionResult Update(Employee c)
        {
            try
            {
                c.Shop = ctx.Shops.Find(c.ShopId);
                if (ModelState.IsValid)
                {
                    Employee employee = ctx.Employees.Single(a => a.EmployeeId == c.EmployeeId);
                    if (TryUpdateModel(employee))
                    {
                        employee.Name = c.Name;
                        employee.Address = c.Address;
                        ctx.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View("Edit", c);
            }
            catch (Exception e)
            {
                return View("Edit", c);
            }
        }

        // DELETE: /Employees/Delete/id
        [HttpDelete]
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                Employee employee = ctx.Employees.Find(id);
                if (employee != null)
                {
                    ctx.Employees.Remove(employee);
                    ctx.SaveChanges();
                    return RedirectToAction("Index");
                }
                return HttpNotFound("Couldn't find the employee with id " + id.ToString());
            }
            return HttpNotFound("Missing employee id parameter!");
        }
    }
}