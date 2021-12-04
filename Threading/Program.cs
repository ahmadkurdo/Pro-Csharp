using System;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // SimpleThreadExample.Run();
            // ParametrizedThreadExample.Run();
            // SmartThreading.AutoResetEventExample.Run();
            // ConcurrencyIssues.IssuesOfConcurrencyExample.Run();
            // ThreadSynchronization.SynchronizingThreadsExample.Run();
            // TimerCallbackExample.Run();
            // TeaMaker.MakeTea();
            await TeaMaker.MakeTeaAsync();
        }
    }

}
