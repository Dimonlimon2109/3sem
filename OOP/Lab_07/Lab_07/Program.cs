using Lab_07;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        //проверка обобщенного интерфейса на базе класса с массивом
        try
        {
            CustomQueue<int> queue = new CustomQueue<int>(1, 2, -10, 6);

            queue.Print("queue:");

            // Добавить элемент
            int newNum = 130;
            queue.Add(newNum);
            queue.Print($"A1 + [{newNum}]:");

            // Удалить другой элемент
            int delNum = 1;
            queue.Delete();
            queue.Print("A1 -");

            //****обработчик исключений****
            try
            {
                CustomQueue<int> queue5 = new CustomQueue<int>();
                queue5.Delete();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("\nОшибка: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("------------------------------");
            }


            //int,string, double
            CustomQueue<string> str_queue = new CustomQueue<string>("Hello", "Vanya", "lOX");
            str_queue.Delete();
            str_queue.Add("Gosha");
            str_queue.Print("Строковая очередь:");
            CustomQueue<int> int_queue = new CustomQueue<int>(10, 20, 30);
            int_queue.Delete();
            int_queue.Add(33);
            int_queue.Print("Целочисленная очередь:");
            CustomQueue<double> doub_queue = new CustomQueue<double>(-2.2, 3.3, 1.58);
            doub_queue.Delete();
            doub_queue.Add(22.22);
            doub_queue.Print("Очередь вещественных чисел:");
            //Parrot queue
            Parrot parrot1 = new("Кеша", 0.7, 2000);
            Parrot parrot2 = new("Артем", 0.8, 2005);
            CustomQueue<Parrot> queue3 = new(parrot1, parrot2);

            queue3.Print();

            Console.ReadKey();

            //запись и чтение в (из) файла
            queue3.ToFile("file.txt");
            Console.ReadKey();

            Console.WriteLine("\nЧтение из файла: ");
            queue3.FromFile("file.txt");
            Console.ReadKey();
        }
        catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }

    }
}
