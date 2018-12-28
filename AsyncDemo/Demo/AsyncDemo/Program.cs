using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Task<int> t = Calculator.AddAsync(5, 5);

            //Console.WriteLine($"result:{t.Result}");

            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;

            Task t = Test.ExecuteAsync(token);
           
            Thread.Sleep(3000);
            source.Cancel();
            t.Wait(token);
            Console.WriteLine($"{nameof(token.IsCancellationRequested)}: {token.IsCancellationRequested}");
            Console.Read();
        }
    }


    internal class Test
    {
        public static async Task ExecuteAsync(CancellationToken token)
        {
            if (token.IsCancellationRequested)
            {
                return;
            }
            await Task.Run(() => CircleOutput(token), token);

        }

        public static void CircleOutput(CancellationToken token)
        {
            Console.WriteLine($"{nameof(CircleOutput)},开始调用");
            for (int i = 0; i < 5; i++)
            {
                if (token.IsCancellationRequested)
                {
                    return;
                }
                Console.WriteLine($"{i + 1}/5 完成");
                Thread.Sleep(1000);
            }
        }
    }
    internal class Calculator
    {
        public static int Add(int m, int n)
        {
            Thread.Sleep(5000);
            return m + n;
        }

        public static async Task<int> AddAsync(int m, int n)
        {
            int result = await Task.Run(() => Add(m, n));
            return result;
        }
    }
}
