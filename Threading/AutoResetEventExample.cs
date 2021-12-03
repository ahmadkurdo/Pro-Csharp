using System;
using System.Threading;

namespace SmartThreading
{
    public class AutoResetEventExample
    {
        static AutoResetEvent _waitHandle = new AutoResetEvent(false);
        public static void Run()
        {
            Console.WriteLine("***** Adding with Thread objects *****");
            Console.WriteLine("ID of thread in Main(): {0}",Thread.CurrentThread.ManagedThreadId);
            
            // Make an AddParams object to pass to the secondary thread.
            AddParams ap = new AddParams(10, 10);
            Thread t = new Thread(new ParameterizedThreadStart(Add));
            t.Start(ap);
            
            // Wait here until you are notified!
            _waitHandle.WaitOne();
            Console.ReadLine();
        }

        static void Add(object data)
        {
            if (data is AddParams ap)
            {
                Console.WriteLine("ID of thread in Add(): {0}",Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("{0} + {1} is {2}",ap.a, ap.b, ap.a + ap.b);
                // Tell other thread we are done.
                _waitHandle.Set();
            }
        }
        
    }

    class AddParams
    {
        public int a, b;
        public AddParams(int numb1, int numb2)
        {
            a = numb1;
            b = numb2; 
        }
    }
}