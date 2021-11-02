using System;
using System.Threading.Tasks;

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

    public class ParallelCounter
    {
        private readonly object _syncObject = new object();

        private int _counter;

        public int Increment()
        {
            var taskOne = Task.Run(Inc);
            var taskTwo = Task.Run(Inc);

            taskOne.Wait();
            taskTwo.Wait();

            return _counter;
        }

        public async Task<int> IncrementAsync()
        {
            var taskOne = Task.Run(Inc);
            var taskTwo = Task.Run(Inc);

            await taskOne;
            await taskTwo;

            return _counter;
        }

        private void Inc()
        {
            for (var i = 0; i < 1_000_000; i++)
            {
                lock (_syncObject)
                {
                    _counter++;
                }
            }
        }
    }
}
