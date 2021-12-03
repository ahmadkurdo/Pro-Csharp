using System;
using System.Threading;

namespace Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleThreadExample.Run();
            ParametrizedThreadExample.Run();
            SmartThreading.AutoResetEventExample.Run();
            ConcurrencyIssues.IssuesOfConcurrencyExample.Run();
        }
    }

}
