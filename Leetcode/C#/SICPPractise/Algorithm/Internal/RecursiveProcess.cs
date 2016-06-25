using System;

namespace SICPPractise.Algorithm.Internal
{
    internal static class RecursiveProcess
    {
        public static int Factorial(int n)
        {
            Console.WriteLine("This is recursive process result.");
            return n == 1 ? 1 : n * Factorial(n - 1);
        }

        public static int Fibonacci(int n)
        {
            Console.WriteLine("This is recursive process result.");
            switch (n)
            {
                case 1:
                    return 0;
                case 2:
                    return 1;
                default:
                    return Fibonacci(n - 1) + Fibonacci(n - 2);
            }
        }
    }
}
