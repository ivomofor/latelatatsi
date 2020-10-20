using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pilot.Models.Repository;
using Pilot.Models;
using Pilot.Services;
using Pilot.Data;

namespace Pilot.Controllers
{
    public class CasualEmployeeController : Controller
    {

        private readonly ICasualEmployeeRepository casualRepo;
        private readonly ITask task;
        private readonly ApplicationDbContext context;
        private readonly ISavedTask savedTask;
        public CasualEmployeeController(ICasualEmployeeRepository caRepo, ITask tk, ApplicationDbContext ctx, ISavedTask st)
        {

            casualRepo = caRepo;
            task = tk;
            context = ctx;
            savedTask = st;
        }
        public IActionResult Index()
        {
            return View(casualRepo.GetAllCasual());
        }

        public IActionResult Create(CasualEmployee employee)
        {
            return View(employee);
        }

        [HttpPost]
        public IActionResult CreateEmployee(CasualEmployee employee)
        {
            if(ModelState.IsValid)
            {
                var em = casualRepo.GetAllCasual().FirstOrDefault(m => m.Email == employee.Email);
                if (em == null)
                {
                    casualRepo.CreateCasual(employee);
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
        public IActionResult Edit(CasualEmployee employee)
        {
            CasualEmployee em = casualRepo.GetAllCasual().FirstOrDefault(em => em.Id == employee.Id);
            return View(em);
        }

        [HttpPost]
        public IActionResult EditEmployee(CasualEmployee employee)
        {
            if (ModelState.IsValid)
            {
                casualRepo.EditEmployee(employee);
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
        public IActionResult DeleteCasual(int id)
        {
            CasualEmployee em = casualRepo.DeleteCasual(id);
            if (em != null)
            {
                TempData["message"] = $"{em.FirstName} was deleted";
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DoTask()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DoTask(CasualEmployee casual)
        {
            CasualEmployee ca = casualRepo.GetAllCasual().FirstOrDefault(c => c.FirstName == casual.FirstName);
            if (ca != null)
            {
                var result = task.Action1(ca.FirstName, ca.LastName);
                savedTask.SavedTaskResult($"{result} with Employment Level: {ca.Role}");
                return View(nameof(Result), $"{result} with Employment Level: {ca.Role}");
            }
            return View(casual);
        }
        public IActionResult Result()
        {
            return View();
        }
        public IActionResult TaskHistory()
        {
            return View(savedTask.GetAllTask());
        }

    }
}
