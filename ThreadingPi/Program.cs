using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingPi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dartThrowsPerThread = 0;
            int numThreads = 0;
            int dartsLanded = 0;

            Console.WriteLine("How many dart throws per thread?");
            dartThrowsPerThread = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("How many threads?");
            numThreads = Convert.ToInt32(Console.ReadLine());

            List<Thread> threads = new List<Thread>();
            List<FindPiThread> findPiThreads = new List<FindPiThread>();

            for(int i = 0; i < numThreads; i++)
            {
                FindPiThread f = new FindPiThread(dartThrowsPerThread);
                findPiThreads.Add(f);

                Thread t = new Thread(new ThreadStart(f.throwDarts));
                threads.Add(t);

                t.Start();
                Thread.Sleep(16);
            }

            foreach(Thread x in threads) 
            {
                x.Join();
            }

            foreach(FindPiThread y in findPiThreads)
            {
                dartsLanded += y.getDartsLanded();
            }

            double piEval = (4.0 * (dartsLanded) / (numThreads * dartThrowsPerThread));

            Console.WriteLine("Evaluation of Pi = " + piEval);

            Console.WriteLine("\nPress a key to exit...");
            Console.ReadKey();
        }
    }
}
