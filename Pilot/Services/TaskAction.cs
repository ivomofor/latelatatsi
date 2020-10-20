using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Pilot.Services
{
    public class TaskAction : ITask
    {
        public string Action1(string name1, string name2)
        {
            int y = 0;
            Random r = new Random();
            var ran = r.Next(999, 999);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (y = 0; y <= ran; y++)
            {
                int x = 0;
                Random random = new Random();
                var ranNum = random.Next(999, 999);
                for (x = 0; x <= ranNum; x++)
                {
                    int w = 0;
                    Random random1 = new Random();
                    var ranNum1 = random1.Next(99, 999);
                    for (w = 0; w <= ranNum1; w++)
                    { }
                }
            }
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            Debug.WriteLine($"{ts} time......");
            Debug.WriteLine("Finished {0} loop iterations", y);
            return $"{name1} {name2} has completted the Task with time {ts}";
        }
        public string Action2(string name1, string name2, int num)
        {
            int i = 0;
            Random r = new Random();
            var ran = r.Next(1000, 100000000);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (i = 0; i <= ran; i++)
            {
                int x = 0;
                Random random = new Random();
                var ranNum = random.Next(1000, 100000000);
                for (x = 0; x <= ranNum; x++)
                { }
            }
            stopwatch.Stop();
            TimeSpan ts = TimeSpan.FromSeconds(num);
            TimeSpan sec = stopwatch.Elapsed;
            Debug.WriteLine("Finished {0} loop iterations", i);
            return $"{name1} {name2} has worked for {num}  completted the Task with time {sec}";
        }
    }
}
