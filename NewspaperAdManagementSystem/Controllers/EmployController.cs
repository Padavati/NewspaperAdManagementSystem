using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
       
        public IActionResult EditEmployDetails(int EmpID)//select*from set EmployDetails where EmpID
        {
            
            var employdetails = _connection.EmployDetails.Find(EmpID);                  
            
            return View(employdetails);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditEmployDetails(EmployDetailsClass employDetailsClass)
        {
            _connection.Entry(employDetailsClass).State = EntityState.Modified;
            //_connection.Update(employDetailsClass);
            _connection.SaveChanges();
            ViewBag.message = "Updated Successfully";
            return View(employDetailsClass);
        }
        public IActionResult DeleteEmployDetails(int EmpID)//Deletion
        {
            var employeeDetails = _connection.EmployDetails.Find(EmpID);
            return View(employeeDetails);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteEmployDetails(EmployDetailsClass employDetailsClass)
        {
            //_connection.Entry(employDetailsClass).State = EntityState.Deleted;
            _connection.EmployDetails.Remove(employDetailsClass);
            await _connection.SaveChangesAsync();
            ViewBag.message = "Deleted Successfully";
            return View(employDetailsClass);
        }
    }
}
