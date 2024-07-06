using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_14
{
    static class TwoThread
    {
        public static Mutex mutexObj = new();
        private static object lockObject = new object(); // Объект блокировки для синхронизации
        private static bool isEvenTurn = true; // Переключатель для определения, чей ход
        public static void CreateThreadi(int n)
        {
            Thread evenThread = new Thread(() => PrintNumbersi(true, n));
            Thread oddThread = new Thread(() => PrintNumbersi(false, n));
            evenThread.Priority = ThreadPriority.Highest;
            oddThread.Priority = ThreadPriority.Lowest;
            evenThread.Start();
            Thread.Sleep(500);
            oddThread.Start();
            evenThread.Name = ("CreateThread_1");
            oddThread.Name = ("CreateThread_2");
        }

        public static void CreateThreadii (int n)
        {
            // Создаем два потока
            Thread evenThread = new Thread(() => PrintNumbersii(true, n));
            Thread oddThread = new Thread(() => PrintNumbersii(false, n));

            // Устанавливаем разные приоритеты для потоков
            evenThread.Priority = ThreadPriority.AboveNormal;
            oddThread.Priority = ThreadPriority.BelowNormal;

            // Запускаем потоки
            evenThread.Start();
            oddThread.Start();

            // Ждем завершения обоих потоков
            evenThread.Join();
            oddThread.Join();

            Console.WriteLine("Главный поток завершается.");
        }
        static void PrintNumbersii(bool isEven, int n)
        {
            Thread.Sleep(2000);
            for (int i = isEven ? 2 : 1; i <= n; i += 2)
            {
                lock (lockObject)
                {
                    // Проверка, чей сейчас ход
                    while ((isEven && !isEvenTurn) || (!isEven && isEvenTurn))
                    {
                        Monitor.Wait(lockObject);
                    }

                    // Вывод в файл и на консоль
                    using (StreamWriter writer = new StreamWriter("output.txt", true))
                    {
                        writer.WriteLine(i);
                    }

                    Console.Write($"\n{i}");

                    // Переключаем ход
                    isEvenTurn = !isEvenTurn;

                    // Сигнализируем другому потоку
                    Monitor.Pulse(lockObject);
                }

                // Задержка для эмуляции разной скорости потоков
                Thread.Sleep(isEven ? 300 : 500);
            }
        }
        static void PrintNumbersi(bool isEven, int n)
        {
            Thread.Sleep(2000);
                lock (lockObject)
                {
                    // Проверка, чей сейчас ход
                    while ((isEven && !isEvenTurn) || (!isEven && isEvenTurn))
                    {
                        Monitor.Wait(lockObject);
                    }
                for (int i = isEven ? 2 : 1; i <= n; i += 2)
                {
                    // Вывод в файл и на консоль
                    using (StreamWriter writer = new StreamWriter("output.txt", true))
                    {
                        writer.WriteLine(i);
                    }

                    Console.Write(i + " ");
                }
                Console.WriteLine('\n');
                // Переключаем ход
                isEvenTurn = !isEvenTurn;

                // Сигнализируем другому потоку
                Monitor.Pulse(lockObject);
                // Задержка для эмуляции разной скорости потоков
                Thread.Sleep(isEven ? 300 : 500);
            }
        }
    }
}
