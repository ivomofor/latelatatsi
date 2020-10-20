using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pilot.Models.Repository
{
    public interface ICasualEmployeeRepository
    {
        CasualEmployee GetCasual(int id);
        IEnumerable<CasualEmployee> GetAllCasual();
        void CreateCasual(CasualEmployee casual);
        CasualEmployee EditEmployee(CasualEmployee employee);
        CasualEmployee DeleteCasual(int id);
    }
}
