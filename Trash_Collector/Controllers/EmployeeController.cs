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
using GoogleMaps.LocationServices;

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
            ResetPickUpDayConfirmation();

            if (employee == null)
            {
                return RedirectToAction("Create");

            }
            else
            {
                var customers = _context.Customers.Include(c => c.PickUpDay).ToList();
                var customersInZipCode = customers.Where(c => c.ZipCode == employee.ZipCodeAssignment && c.ConfirmPickUp == false).ToList();
                var dayOfWeekString = DateTime.Now.DayOfWeek.ToString();
                var todayString = DateTime.Today.ToString();
                var today = DateTime.Today;
                SetExtraPickUpDayString(customersInZipCode);
                var customersInZipAndToday = customersInZipCode.Where(c => c.PickUpDay.Date == dayOfWeekString || c.ExtraPickUpDayString == todayString).ToList();
                SetSuspensionDates(customersInZipAndToday);
                var customersWithoutSuspends = customersInZipAndToday.Where(c => (c.SuspendStartDate == null && c.SuspendEndDate == null) || c.SuspendStartDate > today || c.SuspendEndDate < today).ToList();

                return View(customersWithoutSuspends);

            }


        }

        private void SetExtraPickUpDayString(List<Customer> customers)
        {
            foreach(Customer customer in customers)
            {
                if(customer.ExtraPickUpDay.HasValue == true)
                {
                    var customerDateString = customer.ExtraPickUpDay.Value.Date.ToString();
                    customer.ExtraPickUpDayString = customerDateString;

                }
                
            }

        }

        private void SetSuspensionDates(List<Customer> customers)
        {
            foreach(Customer customer in customers)
            {
                if(customer.SuspendStartDate.HasValue == true && customer.SuspendEndDate.HasValue == true)
                {
                    TimeSpan ts = new TimeSpan(0, 0, 0);
                    var startTimeAdjust = customer.SuspendStartDate.Value.Date + ts;
                    customer.SuspendStartDate = startTimeAdjust;
                    var endTimeAdjust = customer.SuspendEndDate.Value.Date + ts;
                    customer.SuspendEndDate = endTimeAdjust;
                    
                }
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

            CustomersByPickUpDay customersList = new CustomersByPickUpDay();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.Where(c => c.IdentityUserId == userId).SingleOrDefault();

            var selection = customer.PickUpDaySelection;
            var customers = _context.Customers.Include(c => c.PickUpDay).ToList();
            customersList.Customers = customers.Where(c => c.ZipCode == employee.ZipCodeAssignment && c.PickUpDay.Date == selection).ToList();
            customersList.PickUpDaySelections = new SelectList(_context.PickUpDays, "Date", "Date");

            return View("Filter", customersList);

        }

        public ActionResult Map(int id)
        { 

            CustomerAddress address = new CustomerAddress();
            var locationService = new GoogleLocationService(apikey: "AIzaSyCb3d1Jb7e06yFVxKXS9EdB2O_ofBEarr0");
            var customer = _context.Customers.Find(id);

            address.StreetAddress = customer.StreetAddress;
            address.City = customer.City;
            address.State = customer.State;
            address.ZipCode = customer.ZipCode;

            var fullAddress = $"{address.StreetAddress} {address.City} {address.State} {address.ZipCode}";
            var point = locationService.GetLatLongFromAddress(fullAddress);
            address.Latitude = point.Latitude;
            address.Longitude = point.Longitude;

            return View(address);
        }

        public ActionResult Create() // GET
        {
            Employee employee = new Employee();
            return View(employee);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee) // POST
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

        public ActionResult Confirm(int id)// GET

        {
            var customer = _context.Customers.Where(c => c.Id == id).Single();
            return View(customer);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Confirm(Customer customer)// POST
        {
            try
            {
                if(customer.ConfirmPickUp == true)
                {
                    customer.CurrentBalance += 100.00;
                    customer.LastChargedDay = DateTime.Today;
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

        private void ResetPickUpDayConfirmation()
        {
            var customers = _context.Customers.Include(m => m.PickUpDay).ToList();
            DateTime today = DateTime.Today;
            DateTime yesterday = today.AddDays(-1);

            foreach(Customer customer in customers)
            {
                if(customer.LastChargedDay == yesterday)
                {
                    customer.ConfirmPickUp = false;
                }
            }
        }


    }
}
