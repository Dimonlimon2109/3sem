using Lab_15;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Lab_15
{
    class Program
    {
        static void Main()
        {
            int n = 20;
            Stopwatch stopwatch = new Stopwatch();
            Task task1 = new(() => SearchSimpleNum.ReshetoEratosfena(n));
            stopwatch.Start();
            task1.Start();
            task1.Wait();
            stopwatch.Stop();
            Thread.Sleep(1000);
            TimeSpan timeSpan = stopwatch.Elapsed;
            Console.WriteLine("Время выполнения задачи " + task1.Id + ": " + timeSpan);
            Console.WriteLine("Идентификатор текущей задачи:" + task1.Id + "\tСтатус задачи:" + task1.Status + "\tЗадача завершена:" + task1.IsCompleted);
            stopwatch.Reset();
            Thread.Sleep(1000);
            Console.WriteLine();
            n = 1000;

            // Создаем CancellationTokenSource для возможности отмены задачи
            var cts = new CancellationTokenSource();

            // Создаем токен отмены из CancellationTokenSource
            CancellationToken token = cts.Token;

            var task2 = Task.Run(() => SearchSimpleNum.ReshetoEratosfenaToken(n, token));
            Stopwatch stopwatch2 = Stopwatch.StartNew();
            Thread.Sleep(2000);
            if(!task2.IsCompleted)
            {
                cts.Cancel();
            }
            else
            {
                task2.Wait();
            }
            if (token.IsCancellationRequested)
            {
                Console.WriteLine("Операция прервана с помощью токена отмены");
            }
            Console.WriteLine("Время выполнения задачи " + task1.Id + ": " + timeSpan);
            Console.WriteLine("Идентификатор текущей задачи:" + task1.Id + "\tСтатус задачи:" + task1.Status + "\tЗадача завершена:" + task1.IsCompleted);
            //task3
            Task<int> elem1 = new(() => Formula._mul(6, 7, 8));
            Task<int> elem2 = new(() => Formula._sum(3, 7, 10));
            Task<int> elem3 = new(() => Formula._pow(3, 4));
            Task task3 = new(() =>
            {
                elem1.Start();
                elem1.Wait();
                elem2.Start();
                elem2.Wait();
                elem3.Start();
                elem3.Wait();
                int result = 0;
                result = elem1.Result + elem2.Result + elem3.Result;
                Console.WriteLine("\n\nРезультат вычислений: " + result);
            });
            task3.Start();
            task3.Wait();
            //task4.1
            Task<int> task4 = new(() => Formula._sum(13, 15, 7, 8));
            Task task4Continue = task4.ContinueWith(task =>
            {
                int result = task4.Result * task4.Result;
                Console.WriteLine("\n\n\nКвадрат суммы чисел:" + task4.Result);
            });
            task4.Start();
            task4Continue.Wait();
            //task4.2
            Task<int> task4_2 = Task.Run(() => Formula._pow(2,4));
            var awaiter = task4_2.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                int res = awaiter.GetResult();
                Console.WriteLine("\n\n\n" + res);
            });
            //task5
            int[][] task5 = LongArray.GenerateArrayParallel();
            /*             Console.WriteLine("Массив" + 1);
                           for (int j = 0; j < 1000000; j++)
                           {
                               Console.Write($"{task5[0][j]}, ");
                           }*/
            //task6
            Parallel.Invoke(
                () => Formula._sumOutput(10, 5, 6, 7),
                () => Formula._mulOutput(5, 2, 3),
                () => Formula._powOutput(3, 2)
                );
            //task7&8
            Console.WriteLine();
            Trade.TradeAsync().Wait();

        }
    }
}