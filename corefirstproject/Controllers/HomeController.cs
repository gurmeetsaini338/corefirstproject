using corefirstproject.connetion;
using corefirstproject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace corefirstproject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public object EntityStates { get; private set; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult table()
        {
            companydataContext entities = new companydataContext();
            var res = entities.Employforms.ToList();
            return View(res);
        }
        public IActionResult add_emp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult add_emp(Class mod)
        {
            companydataContext ent = new companydataContext();
            Employform tbl = new Employform();
            tbl.Id = mod.Id;
            tbl.Name = mod.Name;
            tbl.Salary = mod.Salary;
            tbl.Depart = mod.Depart;
            tbl.City = mod.City;
            if (mod.Id == 0)
            {
                ent.Employforms.Add(tbl);
                ent.SaveChanges();
                return RedirectToAction("table");
            }
            else
            {
                ent.Entry(tbl).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                ent.SaveChanges();
                return RedirectToAction("table");
            }




        }
        public IActionResult Edit(int Id)
        {
            companydataContext ent = new companydataContext();
            var edit = ent.Employforms.Where(m => m.Id == Id).First();
            Employform obj = new Employform();
            obj.Id = edit.Id;
            obj.Name = edit.Name;
            obj.Salary = edit.Salary;
            obj.City = edit.City;
            obj.Depart = edit.Depart;
            return View("add_emp", obj);

        }
        public IActionResult delete(int id)
        {
            companydataContext ent = new companydataContext();
            var dlt = ent.Employforms.Where(m => m.Id == id).First();
            ent.Employforms.Remove(dlt);
            ent.SaveChanges();
            return RedirectToAction("table");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
