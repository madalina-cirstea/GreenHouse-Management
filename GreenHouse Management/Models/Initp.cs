using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GreenHouse_Management.Models
{
    public class Initp : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
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

            SensorUsage usage0 = new SensorUsage { RecordedType = "Temperature", MeasurementUnit = "°F", Description = "measurement range between -4°F and 95°F" };
            ctx.SensorUsages.Add(usage0);

            SensorUsage usage1 = new SensorUsage { RecordedType = "Temperature", MeasurementUnit = "°C", Description = "measurement range between -20°C and +35°C" };
            ctx.SensorUsages.Add(usage1);

            SensorUsage usage2 = new SensorUsage { RecordedType = "Humidity", MeasurementUnit = "mg/l", Description = "measurement range 0.2 - 5 mg/l" };
            ctx.SensorUsages.Add(usage2);

            SensorUsage usage3 = new SensorUsage { RecordedType = "Soil moisture", MeasurementUnit = "Volumetric (%)", Description = "measurement range 0 - 10" };
            ctx.SensorUsages.Add(usage3);

            ctx.SaveChanges();
            base.Seed(ctx);
        }
    }
}