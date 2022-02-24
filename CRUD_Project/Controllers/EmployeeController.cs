using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_Project.Models;

namespace CRUD_Project.Controllers
{
    public class EmployeeController : Controller

    {
        public ApplicationDbContext DbContext;
        
        public EmployeeController(ApplicationDbContext DbContext)
        {
            this.DbContext = DbContext;
        }
      
        public IActionResult Index()
        {
            List<Employee> Emps = DbContext.Employees.ToList();

            return View(Emps);
        }
        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee Emp)
        {
            DbContext.Employees.Add(Emp);
            DbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
