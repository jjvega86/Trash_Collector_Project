using System;
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
using Trash_Collector.Models.ViewModels;

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
                var customersInZipCode = customers.Where(c => c.ZipCode == employee.ZipCodeAssignment && c.ConfirmPickUp == false).ToList();
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
            // make an instance of the viewmodel
            CustomersByPickUpDay customersList = new CustomersByPickUpDay();

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.Where(c => c.IdentityUserId == userId).SingleOrDefault();


            // find and attach indivual properties of the viewmodel

            var customers = _context.Customers.Include(c => c.PickUpDay).ToList();
            customersList.Customers = customers.Where(c => c.ZipCode == employee.ZipCodeAssignment).ToList();

            customersList.PickUpDaySelections = new SelectList(_context.PickUpDays, "Date", "Date");

            return View(customersList);
        }

        //POST: EmployeeController/Filter
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Filter(CustomersByPickUpDay customer)
        {

            //instance of view model to pass
            //grabbing currently logged in employee

            CustomersByPickUpDay customersList = new CustomersByPickUpDay();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.Where(c => c.IdentityUserId == userId).SingleOrDefault();

            //use passed in string property of PickUpDaySelection to query database for only customers on that day
            var selection = customer.PickUpDaySelection;
            var customers = _context.Customers.Include(c => c.PickUpDay).ToList();
            customersList.Customers = customers.Where(c => c.ZipCode == employee.ZipCodeAssignment && c.PickUpDay.Date == selection).ToList();
            customersList.PickUpDaySelections = new SelectList(_context.PickUpDays, "Date", "Date");


            //return to the original filter view, passing in the now filtered CustomersByPickUpDay view model
            return View("Filter", customersList);

        }

        // GET: EmployeeController/Map
        public ActionResult Map(int id)
        {
            // I want to select the customer profile and see their address with a pin on a map
            // using an address view model that grabs all the relevant address properties from the customer
            // I'll then pass in that viewmodel to a view that displays the address and a map with a pin
            // using Google API

            // Step 1: Build view model X
            // Step 2: Build view X
            // Step 3: Write initial logic in Details action to display address X
            // Step 4: Research Google APIs and identify next steps to implement ***
            // Step 5: Add a property to CustomerAddress view model that has all address properties concatenated X
            // Step 6: Add logic to concatenate address properties to FullAddress property that will be passed into view with rest of viewmodel X

            CustomerAddress address = new CustomerAddress();

            var customer = _context.Customers.Find(id);

            address.StreetAddress = customer.StreetAddress;
            address.City = customer.City;
            address.State = customer.State;
            address.ZipCode = customer.ZipCode;
            string stringZipCode = address.ZipCode.ToString();
            address.FullAddress = $"{customer.StreetAddress} {customer.City} {customer.State} {stringZipCode}";
            return View(address);
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
                if(customer.ConfirmPickUp == true)
                {
                    customer.CurrentBalance += 100;
                }
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
