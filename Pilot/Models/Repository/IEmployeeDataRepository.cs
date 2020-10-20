using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pilot.Models.Repository
{
    public interface IEmployeeDataRepository
    {
        Employee GetEmployee(int id);
        IEnumerable<Employee> GetAllEmployee();
        void CreateEmployee(Employee employee);
        Employee EditEmployee(Employee employee);
        Employee DeleteEmployee(int id);
        Employee FindResult(Employee employee);
    }
}
