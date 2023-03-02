using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadingPi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dartThrowsPerThread = 0;
            int numThreads = 0;

            Console.WriteLine("How many dart throws per thread?");
            dartThrowsPerThread = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("How many threads?");
            numThreads= Convert.ToInt32(Console.ReadLine());
        }
    }
}
