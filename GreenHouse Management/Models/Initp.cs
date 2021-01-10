using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GreenHouse_Management.Models
{
    public class Initp : DropCreateDatabaseAlways<ApplicationDbContext>
    { 
        protected override void Seed(ApplicationDbContext ctx)
        {
            Shop shop1 = new Shop { Name = "Agrii", BIN = "RO1234", Address = "Str. Ion Bravu, Bucuresti" };
            Shop shop2 = new Shop { Name = "GreenLife", BIN = "UK5678", Address = "st. Mary the I, England" };
            ctx.Shops.Add(shop1);
            ctx.Shops.Add(shop2);

            Employee emp1 = new Employee
            {
                Name = "Mihai Campeanu",
                EIN = "a1234",
                Address = "Bucuresti, RO",
                ShopId = shop1.ShopId,
                Shop = shop1
            };
            Employee emp2 = new Employee
            {
                Name = "John Smith",
                EIN = "a5678",
                Address = "Englad, UK",
                ShopId = shop2.ShopId,
                Shop = shop2
            };
            ctx.Employees.Add(emp1);
            ctx.Employees.Add(emp2);

            ctx.SaveChanges();
            base.Seed(ctx);
        }
    }
}