// Name: Vance Brender-A-Brandis
// Date: 3/4/23
// Description: Main() for Pi evaluation program

using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            int dartThrowsPerThread = 0; // Num dart throws per thread
            int numThreads = 0; // Number of threads to use
            int dartsLanded = 0; // Number of darts that landed within the 1/4 area (retrieved using an accessor)

            List<Thread> threads = new List<Thread>(); // List of threads
            List<FindPiThread> findPiThreads = new List<FindPiThread>(); // List of FindPiThread objects

            Stopwatch sw = new Stopwatch(); // Used to track time taken for the calculations and such

            Console.WriteLine("How many dart throws per thread?");
            dartThrowsPerThread = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("How many threads?");
            numThreads = Convert.ToInt32(Console.ReadLine());

            
            // Sets up threads and starts them
            for(int i = 0; i < numThreads; i++)
            {
                FindPiThread f = new FindPiThread(dartThrowsPerThread);
                findPiThreads.Add(f);

                Thread t = new Thread(new ThreadStart(f.throwDarts));
                threads.Add(t);

                t.Start();
                Thread.Sleep(16);
            }

            // Loops over each thread in the thread List and tells Main() to wait till they're finished
            foreach(Thread x in threads) 
            {
                x.Join();
            }

            // Just retrieves the landed darts from the FindPiThread objects in the appropriate List
            foreach(FindPiThread y in findPiThreads)
            {
                dartsLanded += y.getDartsLanded();
            }

            // Quick Pi evaluation (have to multiple numThreads by dartThrowsPerThread for total throws)
            // ** Multiply by 4.0 to actually get a double result. Without the decimal, you just get an integer in return.
            double piEval = (4.0 * (dartsLanded) / (numThreads * dartThrowsPerThread));

            Console.WriteLine("Evaluation of Pi = " + piEval);

            Console.WriteLine("\nPress a key to exit...");
            Console.ReadKey();
        }
    }
}
