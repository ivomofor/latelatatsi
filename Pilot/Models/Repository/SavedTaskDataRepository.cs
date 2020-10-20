using Pilot.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pilot.Models.Repository
{
    public class SavedTaskDataRepository : ISavedTask
    {
        private readonly ApplicationDbContext context;
        public SavedTaskDataRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public void SavedTaskResult(string result)
        {
            SavedTask st = new SavedTask();
            st.SavedResult = result;
            context.SavedTasks.Add(st);
            context.SaveChanges();
        }
        public IEnumerable<SavedTask> GetAllTask()
        {
            return context.SavedTasks;
        }
    }
}
