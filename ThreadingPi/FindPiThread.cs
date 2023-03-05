using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ThreadingPi
{
    internal class FindPiThread
    {
        private int numDartsToThrow;
        private int numDartsLanded = 0;
        private Random rand;

        public FindPiThread(int dartsToThrow)
        {
            rand = new Random();
            numDartsToThrow = dartsToThrow;
        }

        public int getDartsLanded()
        {
            return numDartsLanded;
        }

        public void throwDarts() 
        {
            double x = 0;
            double y = 0;

            for (int i = 0; i < numDartsToThrow; i++)
            {
                x = rand.NextDouble(); // goes from 0 <= x < 1. 1 cannot be generated
                y = rand.NextDouble(); // same here

                x *= x;
                y *= y;

                double hypotenuse = x + y;

                if(hypotenuse <= 1)
                {
                    numDartsLanded++;
                }
            }
        }
    }
}
