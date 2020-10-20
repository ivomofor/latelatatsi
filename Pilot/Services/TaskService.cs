using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pilot.Services
{
    public class TaskService : BackgroundService
    {
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                static bool Loop1()
                {
                    int count1;
                    for (count1 = 5; count1 > 0; count1--)
                    {
                        int count = 2;
                        while (count > 0)
                        {
                            count--;
                        }
                        Debug.WriteLine("Running Background Task...");
                    }
                    return true;
                    
                }
                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
                Loop1();
            }
        }

    }
}
