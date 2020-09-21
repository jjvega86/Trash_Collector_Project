﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trash_Collector.Data;

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
            //I want to return a list of customers, filtered by today's day of week, employee zip code, extra pickups included, and excluding suspensions

            if (employee == null)
            {
                return RedirectToAction("Create");

            }
            else
            {
                var customersInZipCode = _context.Customers.Where(c => c.ZipCode == employee.ZipCodeAssignment).ToList();
                var today = DateTime.Now.DayOfWeek.ToString();
                var customersInZipAndToday = customersInZipCode.Where(c => c.PickUpDay.Date == today && c.ExtraPickUpDay == DateTime.Today).ToList();
                var customersWithoutSuspends = customersInZipAndToday.Where(c => c.IsSuspended == false).ToList();
                return View(customersWithoutSuspends);

            }


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
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            //I want to 
            return View();
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
