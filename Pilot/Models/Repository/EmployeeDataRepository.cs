using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Pilot.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Pilot.Models.Repository
{
    public class EmployeeDataRepository: IEmployeeDataRepository
    {
        private readonly ApplicationDbContext context;
        public EmployeeDataRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public Employee GetEmployee(int id)
        {
            return context.Employees.Find(id);
        }
        public IEnumerable<Employee> GetAllEmployee()
        {
            return context.Employees;
        }
        public void CreateEmployee(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
        }
        public Employee EditEmployee(Employee employee)
        { 
            context.Employees.Update(employee);
            context.SaveChanges();
            return employee;
        }
        public Employee DeleteEmployee(int id)
        {
            Employee em = context.Employees.FirstOrDefault(em => em.Id == id);
            context.Employees.Remove(em);
            context.SaveChanges();
            return em;
        }

        public Employee FindResult(Employee em)
        {
            return context.Employees.FirstOrDefault(m => m.Id == em.Id);
        }
    }
}
