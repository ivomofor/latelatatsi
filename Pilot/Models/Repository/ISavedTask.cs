using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pilot.Models.Repository
{
    public interface ISavedTask
    {
        void SavedTaskResult(string x);
        IEnumerable<SavedTask> GetAllTask();
    }
}
