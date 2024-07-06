using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_14
{
    static class NewThread
    {
        public static void OutputNumber(object? n)
        {
            int num = (int)n;
            for (int i = 2; i <= num; i++)
            {
                if (IsPrime(i))
                {
                    // Выводим простое число в консоль
                    Console.WriteLine($"Простое число: {i}");

                    // Записываем простое число в файл
                    using (StreamWriter writer = new StreamWriter("primes.txt", true))
                    {
                        writer.WriteLine(i);
                    }

                    // Задержка для эмуляции долгого выполнения задачи
                    Thread.Sleep(500);
                }
            }
        }
        static bool IsPrime(int number)
        {
            if (number < 2)
                return false;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }

        public static void CreateThread(int n)
        {
            Thread myThread = new Thread(new ParameterizedThreadStart(OutputNumber));
            myThread.Start(n);

            // Выводим информацию о статусе потока
            myThread.Name = "NewThread";
            Console.WriteLine("Имя потока: " + myThread.Name + "\t Приоритет: " + myThread.Priority + "\t Числовой идентификатор: " + myThread.ManagedThreadId
                + "\t Состояние потока: " + myThread.ThreadState);
            try
            {
                // Приостанавливаем поток
                myThread.Suspend();

                // Выводим информацию после приостановки
                Console.WriteLine($"Статус потока: {myThread.ThreadState}");

                // Перезапускаем поток
                myThread.Resume();

                // Ждем завершения потока
                myThread.Join();

                Console.WriteLine("Главный поток завершается.");
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
    }
}
