# ThreadingPi - Vance Brender-A-Brandis #

## Description ## 
- This assignment involves practicing threading by using the Monte Carlo method to estimate the value of Pi using said threads.

## Project Details ##
- Contains two classes: Program and FindPiThread.
- The Program class, from within Main(), creates a list of Threads and FindPiThreads along with other variables to track how many threads to use, number of dart throws to use, and the number of darts that landed within the specified area (for use in calculating Pi)
- The FindPiThread class takes an argued value of darts to throw and generates random doubles for use in calculating c^2 (from the Pythagorean Theorem) and determines if the dart throw landed within the targeted area.

## Extra Credit ##
- The one and only extra credit done for this assignment was in the use of a Stopwatch object to record the time it takes for the threads to finish their processes and outputting that elapsed time after the Pi calculation.
