// Name: Vance Brender-A-Brandis
// Date: 3/4/23
// Description: FindPiThread class used to generate random integers for use in calculating Pi

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
        private int numDartsToThrow; // Number of darts to throw within the object
        private int numDartsLanded = 0; // Number of darts that lands within the targeted area (area from (0,1))
        private Random rand; // Used to generate some random integers

        public FindPiThread(int dartsToThrow)
        {
            rand = new Random(); // Initialize rand
            numDartsToThrow = dartsToThrow; // Sets number of darts to throw from argument
        }

        public int getDartsLanded()
        {
            return numDartsLanded; // Returns number of darts that landed within the targeted area
        }

        public void throwDarts() 
        {
            double x = 0;
            double y = 0;

            for (int i = 0; i < numDartsToThrow; i++)
            {
                x = rand.NextDouble(); // goes from 0 <= x < 1. 1 cannot be generated
                y = rand.NextDouble(); // same here

                x *= x; // This is x^2. Used for Pythagorean Theorem calculation
                y *= y; // This is y^2. Used for Pythagorean Theorem calculation
                // The square root doesn't have to be calculated in this instance

                double hypotenuse = x + y;

                if(hypotenuse <= 1)
                {
                    numDartsLanded++;
                }
            }
        }
    }
}
