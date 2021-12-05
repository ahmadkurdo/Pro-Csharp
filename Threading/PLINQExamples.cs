using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    public class PLINQExamples
    {
        public static void Run()
        {
            Console.WriteLine("Start any key to start processing");
            Console.ReadKey();
            Console.WriteLine("Processing");
            Task.Factory.StartNew(ProcessIntData);
            Console.ReadLine();
            void ProcessIntData()
            {
                // Get a very large array of integers.
                int[] source = Enumerable.Range(1, 10_000_000).ToArray();
                // Find the numbers where num % 3 == 0 is true, returned
                // in descending order.
                int[] modThreeIsZero = (
                  from num in source
                  where num % 3 == 0
                  orderby num descending
                  select num).ToArray();
                Console.WriteLine($"Found { modThreeIsZero.Count()} numbers that match query!");
            }

        }
        public static void RunAsParalles()
        {
            Console.WriteLine("Start any key to start processing");
            Console.ReadKey();
            Console.WriteLine("Processing");
            Task.Factory.StartNew(ProcessIntData);
            Console.ReadLine();
            void ProcessIntData()
            {
                // Get a very large array of integers.
                int[] source = Enumerable.Range(1, 10_000_000).ToArray();
                // Find the numbers where num % 3 == 0 is true, returned
                // in descending order.
                int[] modThreeIsZero = (
                  from num in source.AsParallel()
                  where num % 3 == 0
                  orderby num descending
                  select num).ToArray();
                Console.WriteLine($"Found { modThreeIsZero.Count()} numbers that match query!");
            }

        }
        public static void RunAsParallesWithCancellation()
        {
            CancellationTokenSource _cancelToken = new CancellationTokenSource();
            do
            {
                Console.WriteLine("Start any key to start processing");
                Console.ReadKey();
                Console.WriteLine("Processing");
                Task.Factory.StartNew(ProcessIntData);
                Console.Write("Enter Q to quit: ");
                string answer = Console.ReadLine();
                // Does user want to quit?
                if (answer.Equals("Q",StringComparison.OrdinalIgnoreCase))
                  {
                      _cancelToken.Cancel();
                      break; 
                  }
            } while (true);
            Console.ReadLine();

            void ProcessIntData()
            {
              // Get a very large array of integers.
              int[] source = Enumerable.Range(1, 10_000_000).ToArray();
              // Find the numbers where num % 3 == 0 is true, returned
              // in descending order.
              int[] modThreeIsZero = null;
              try
              {
                modThreeIsZero = (from num in source.AsParallel().WithCancellation(_cancelToken.Token)
                        where num % 3 == 0
                        orderby num descending
                        select num).ToArray();
                Console.WriteLine();
                Console.WriteLine($"Found {modThreeIsZero.Count()} numbers that match query!");
              }
              catch (OperationCanceledException ex)
              {
                Console.WriteLine(ex.Message);
              }
            }

        }
        
    }
}