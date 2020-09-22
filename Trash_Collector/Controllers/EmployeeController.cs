﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trash_Collector.Data;
using Trash_Collector.Models;

namespace Trash_Collector.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeController
        public ActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.Where(c => c.IdentityUserId == userId).SingleOrDefault();

            if (employee == null)
            {
                return RedirectToAction("Create");

            }
            else
            {
                var customers = _context.Customers.Include(c => c.PickUpDay).ToList();
                var customersInZipCode = customers.Where(c => c.ZipCode == employee.ZipCodeAssignment).ToList();
                var todayString = DateTime.Now.DayOfWeek.ToString();
                var today = DateTime.Today;
                var customersInZipAndToday = customersInZipCode.Where(c => c.PickUpDay.Date == todayString || c.ExtraPickUpDay == today).ToList();
                var customersWithoutSuspends = customersInZipAndToday.Where(c => c.IsSuspended == false).ToList();

                return View(customersWithoutSuspends);

            }


        }

        // GET: EmployeeController/Filter - this action pulls up a view with a drop down selectlist to allow filtering by Pick Up Day
        public ActionResult Filter()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            var customers = _context.Customers.Include(c => c.PickUpDay).ToList();
            var customersInZipCode = customers.Where(c => c.ZipCode == employee.ZipCodeAssignment).ToList();

            return View(customersInZipCode);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            // I want to select the customer profile and see their address with a pin on a map
            return View();
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            // I want to create the employee and choose which Zip Code they will cover in their pickups
            //var listofZipCodes = _context.Customers.Select(p => p.ZipCode).Distinct().ToList();
            Employee employee = new Employee();
            return View(employee);

        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                employee.IdentityUserId = userId;
                _context.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(employee);
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.Where(c => c.Id == id).Single();
            return View(customer);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            try
            {
                _context.Update(customer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }
    }
}
