using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial_processor
{
    public class FactorialProcessor
    {
        public void Go(int param, bool parallelMode)
        {
            if (param < 1 || param > 15)
            {
                throw new ArgumentException("param should be between 1 and 15");
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            List<Thread> threads = new List<Thread>();

            if (parallelMode)
            {
                for (int i = 1; i <= param; i++)
                {
                    int copyOfI = i;
                    Thread thread = new Thread(() =>
                    {
                        PrintFactorial(copyOfI, CalculateFactorial(copyOfI));
                    });
                    threads.Add(thread);
                    thread.Start();
                }

                foreach (Thread thread in threads)
                {
                    thread.Join();
                }
            }
            else
            {
                for (int i = 1; i <= param; i++)
                {
                    PrintFactorial(i, CalculateFactorial(i));
                }
            }

            stopwatch.Stop();
            Console.WriteLine($"Execution time: {stopwatch.Elapsed.TotalSeconds} seconds ({stopwatch.Elapsed.TotalMilliseconds} milliseconds)");
        }

        private void PrintFactorial(int number, long factorial)
        {
            Console.WriteLine($"Factorial of {number}: {factorial}");
        }

        private long CalculateFactorial(int n)
        {
            if (n == 1) return 1;
            else
            {
                return n * CalculateFactorial(n - 1);
            }
        }
    }
}