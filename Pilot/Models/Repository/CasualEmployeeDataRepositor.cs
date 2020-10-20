using Pilot.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pilot.Models.Repository
{
    public class CasualEmployeeDataRepositor : ICasualEmployeeRepository
    {
        private readonly ApplicationDbContext context;
        public CasualEmployeeDataRepositor( ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public CasualEmployee GetCasual(int id)
        {
            return context.CasualEmployees.Find(id);
        }
        public IEnumerable<CasualEmployee> GetAllCasual()
        {
            return context.CasualEmployees;
        }
        public void CreateCasual(CasualEmployee casual)
        {
            context.Add(casual);
            context.SaveChanges();
        }
        public CasualEmployee EditEmployee(CasualEmployee employee)
        {
            context.CasualEmployees.Update(employee);
            context.SaveChanges();
            return employee;
        }
        
        public CasualEmployee DeleteCasual(int id)
        {
            CasualEmployee employee = context.CasualEmployees.FirstOrDefault(em => em.Id == id);
            context.CasualEmployees.Remove(employee);
            context.SaveChanges();
            return employee;
        }
    }
}
