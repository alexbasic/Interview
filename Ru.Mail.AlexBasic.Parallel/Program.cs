using System;

namespace Ru.Mail.AlexBasic.Parallel
{
    class Program
    {
        static void Main(string[] args)
        {
            var resultOne = new ParallelCounter().Increment();
            var resultTwo = new ParallelCounter().IncrementAsync().Result;

            Console.WriteLine($"Result: {resultOne}");
            Console.WriteLine($"Result: {resultTwo}");
        }
    }
}
