using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TrådSynkroniseringØvelse1
{
    class Program
    {
        static object _lock = new object();
        static int threadCount = 0;

        static void Main(string[] args)
        {
            Thread countUp = new Thread(new ThreadStart(CountTwoUp));
            Thread countDown = new Thread(new ThreadStart(CountOneDown));

            countUp.Start();
            countDown.Start();
            Console.Read();
        }

        public static void CountTwoUp()
        {
            while (true)
            {

                Monitor.Enter(_lock);
                threadCount++;
                threadCount++;
                Console.WriteLine(threadCount);
                Thread.Sleep(1000);
                Monitor.Exit(_lock);
            }
        }

        public static void CountOneDown()
        {
            while (true)
            {

                Monitor.Enter(_lock);
                threadCount--;
                Console.WriteLine(threadCount);
                Thread.Sleep(1000);
                Monitor.Exit(_lock);
            }
        }
    }
}
