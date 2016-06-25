using System;

namespace SICPPractise.Algorithm.Internal
{
    internal static class IterationProcess
    {
        public static int Factorial(int n)
        {
            Console.WriteLine("This is iterative process result.");
            int y = 1;

            while (n > 1)
            {
                y = y * n;
                n = n - 1;
            }
            return y;
        }

        public static int Fibonacci(int n)
        {
            Console.WriteLine("This is iterative process result.");
            switch (n)
            {
                case 1:
                    return 0;
                case 2:
                    return 1;
                default:
                {
                    var i = 0;
                    var j = 1;
                    var y = 0;
                    while (n > 2)
                    {
                        y = i + j;
                        i = j;
                        j = y;
                        n = n - 1;
                    }
                    return y;
                }
            }
        }
    }
}
