using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pilot.Services
{
    public interface ITask
    {
        string Action1(string name1, string name2);
        string Action2(string name, string name2, int num);
    }
}
