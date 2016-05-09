using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            var myLinkedList = new Dictionary<string, string>
            {
                {"Мельбурн", "Кельн"},
                {"Москва", "Париж"},
                {"Кельн", "Москва"}
            };

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var sorted = LinkedDictionarySort.DictionarySort(myLinkedList);
            stopWatch.Stop();

            FormatOutputInfo(sorted, stopWatch);

            Console.ReadKey();
        }

        private static void FormatOutputInfo(Dictionary<string, string> sorted, Stopwatch stopWatch)
        {
            foreach (var keyValuePair in sorted.Take(100))
                Console.WriteLine(string.Format("({0},{1})", keyValuePair.Key, keyValuePair.Value));

            var ts = stopWatch.Elapsed;
            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds/10);
            Console.WriteLine("RunTime " + elapsedTime);
        }
    }
}
