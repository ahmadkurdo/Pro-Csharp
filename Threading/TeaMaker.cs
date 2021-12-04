using System;
using System.Threading.Tasks;

namespace Threading
{
    public class TeaMaker
    {
        public static string MakeTea()
        {
            var water = BoilWater();
            Console.WriteLine("Take the cups out");
            Console.WriteLine("Put tea in cups");
            var tea = $"Pour {water} in cups";
            Console.WriteLine(tea);
            return tea;
        }
        public static string BoilWater()
        {
            Console.WriteLine("Start the kettle");
            Console.WriteLine("Waiting for the kettle to boil water....");
            Task.Delay(2000).GetAwaiter().GetResult();
            Console.WriteLine("Kettle finished boiling");
            return "Water";

        }
        public static async Task<string> MakeTeaAsync()
        {
            var boilingWater = BoilWaterAsync();
            Console.WriteLine("Take the cups out");
            Console.WriteLine("Put tea in cups");
            string water = await boilingWater;
            var tea = $"Pour {water} in cups";
            Console.WriteLine(tea);
            return tea;
        }
        public static async Task<string> BoilWaterAsync()
        {
            Console.WriteLine("Start the kettle");
            Console.WriteLine("Waiting for the kettle to boil water....");
            /*  Once the thread hits this await it will let go and do something else.
                When the delay is over it will send a signal to the threadpool which 
                will then pick another thread to resume the task 
            */
            await Task.Delay(2000);
            Console.WriteLine("Kettle finished boiling");
            return "Water";

        }
    }
}