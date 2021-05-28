using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TrådSynkroniseringØvelse2
{
    class Program
    {
        public static object _lock = new object();
        public static int counter = 0;

        static void Main(string[] args)
        {
            Thread writeStars = new Thread(new ThreadStart(OutputStars));
            Thread writeHashtags = new Thread(new ThreadStart(OutputHashtags));

            writeStars.Start();
            writeHashtags.Start();

            Console.Read();
        }

        public static void OutputStars()
        {
            while (true)
            {
                Monitor.Enter(_lock);
                try
                {
                    for (int i = 0; i < 60; i++)
                    {
                        Console.Write("*");
                        counter++;
                    }
                    Console.WriteLine(" Count: " + counter);
                    Thread.Sleep(1000);

                }
                catch (Exception e)
                {

                    throw;
                }
                finally
                {
                    Monitor.Exit(_lock);
                }
            }
        }

        public static void OutputHashtags()
        {
            while (true)
            {
                Monitor.Enter(_lock);
                try
                {
                    for (int i = 0; i < 60; i++)
                    {

                        Console.Write("#");
                        counter++;
                    }
                    Console.WriteLine(" Count: " + counter);
                    Thread.Sleep(1000);
                }

                catch (Exception e)
                {

                    throw;
                }

                finally
                {
                    Monitor.Exit(_lock);
                }
            }
        }
    }
}
