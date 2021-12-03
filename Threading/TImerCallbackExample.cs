using System;
using System.Threading;

namespace Threading
{
    public class TimerCallbackExample
    {
        public static void Run()
        {
            Console.WriteLine("***** Working with Timer type *****\n");
            // Create the delegate for the Timer type.
            TimerCallback timeCB = new TimerCallback(PrintTime);
            // Establish timer settings.
            Timer t = new Timer(
                timeCB,     // The TimerCallback delegate object.
                null,       // Any info to pass into the called method (null for no info).
                0,          // Amount of time to wait before starting (in milliseconds).
                1000);      // Interval of time between calls (in milliseconds).
            Console.WriteLine("Hit Enter key to terminate...");
            Console.ReadLine();
        }
        public static void PrintTime(object state)
        {
            Console.WriteLine("Time is: {0}",DateTime.Now.ToLongTimeString());
        }
    }
}