using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pilot.Models;
using Pilot.Models.Repository;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using Pilot.Data;
using Pilot.Services;

namespace Pilot.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeDataRepository employeeRepo;
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ITask task;
        public HomeController( ILogger<HomeController> logger, IWebHostEnvironment hostEnvironment, IEmployeeDataRepository emRepo, ApplicationDbContext ctx, ITask tk)
        {
            _logger = logger;
            employeeRepo = emRepo;
            context = ctx;
            _hostEnvironment = hostEnvironment;
            task = tk;
        }

        public IActionResult Index()
        {
            return View(employeeRepo.GetAllEmployee());
        }
       
        public IActionResult CreateEmployee()
        {

            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Employee employee, IFormFile file) 
        {
            if(ModelState.IsValid)
            {
                var getEm = employeeRepo.GetAllEmployee().FirstOrDefault(m => m.Email == employee.Email);
                if(getEm == null)
                {
                    if (file == null || file.Length == 0)
                        return Content("file not selected");

                    var path = Path.Combine(
                                Directory.GetCurrentDirectory(), "wwwroot/image",
                                file.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    ViewBag.Message = "File Successfully Uploaded";
                    employeeRepo.CreateEmployee(employee);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(nameof(Record), $"User: {employee.FirstName} {employee.LastName} with Email: {employee.Email} already exist!");
                }
            }
            return View(employee);
        }
        public IActionResult Record()
        {
            return View();
        }
        public IActionResult Employee(int id)
        {
            return View(employeeRepo.GetEmployee(id));
        }
        public IActionResult Edit(Employee employee)
        {
            // Querying the database for first or default item with Linq
            Employee em = employeeRepo.GetAllEmployee().FirstOrDefault(em => em.Id == employee.Id);
            //passing Model Data to default View
            return View(em);
        }
        [HttpPost]
        public IActionResult EditEmployee(Employee employee)
        {
           if(ModelState.IsValid)
            {
                employeeRepo.EditEmployee(employee);
                //Using Temp Data for Redirection to EmployeeAction Method
                TempData["Message"] = $"{employee.LastName} has been saved!";
                return RedirectToAction(nameof(Index));
            }
           else
            {
                // there is something wrong with the data values
                return View(employee);
            }
        }
        [HttpPost]
        public IActionResult DeleteEmployee(int id)
        {
            Employee em = employeeRepo.DeleteEmployee(id);
            if (em != null)
            {
                TempData["message"] = $"{em.FirstName} was deleted";
            }
            return RedirectToAction(nameof(Index));
        }
    
        public IActionResult UploadFile()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> UploadFile(IFormFile file)
        //{
        //    if (file == null || file.Length == 0)
        //        return Content("file not selected");

        //    var path = Path.Combine(
        //                Directory.GetCurrentDirectory(), "wwwroot/image",
        //                file.FileName);

        //    using (var stream = new FileStream(path, FileMode.Create))
        //    {
        //        await file.CopyToAsync(stream);
        //    }
        //    ViewBag.Message = "File Successfully Uploaded";
        //    return View();
        //}

        public IActionResult DoTask()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DoTask(Employee employee)
        {
           if(ModelState.IsValid)
            {
                Employee em = employeeRepo.FindResult(employee);
                if (em != null)
                {
                    var result = task.Action2(em.FirstName, em.LastName, em.RatePerHour);
                    return View(nameof(Result), result);
                }
            }
            return View(employee);
        }
        public IActionResult Result()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
