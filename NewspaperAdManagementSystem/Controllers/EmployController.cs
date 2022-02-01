using Microsoft.AspNetCore.Mvc;
using NewspaperAdManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewspaperAdManagementSystem.Controllers
{
    public class EmployController : Controller
    {
        private readonly ConnectionStringClass _connection;
        public EmployController(ConnectionStringClass connection)
        {
            _connection = connection;
        }
        public IActionResult Index()//Select*from EmployDetails
        {
            var employdetails = _connection.EmployDetails.ToList();
            return View(employdetails);
        }
        public IActionResult EmployDetails()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EmployDetails(EmployDetailsClass employDetailsClass)//Insertion into EmployDetails values
        {
            _connection.Add(employDetailsClass);
            _connection.SaveChanges();
            ViewBag.message = "Saved Successfully";
            return View(employDetailsClass);
        }
       
        public IActionResult EditEmployDetails(int EmpID)//select*from EmployDetails where EmpID
        {
            var employdetails = _connection.EmployDetails.Find(EmpID);                  
            ViewBag.message = "Edit operation done successfully";
            return View(employdetails);
        }
    }
}
