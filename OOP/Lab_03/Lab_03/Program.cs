using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;



// Основной класс Queue
public class CustomQueue<T>
{
    // Вложенный объект Production
    class Production
    {
        public int Id { get; set; }
        public string OrganizationName { get; set; }

        public Production(int id, string organizationName)
        {
            Id = id;
            OrganizationName = organizationName;
        }
    }

    // Вложенный класс Developer
    class Developer
    {
        public string FullName { get; set; }
        public int Id { get; set; }
        public string Department { get; set; }

        public Developer(string fullName, int id, string department)
        {
            FullName = fullName;
            Id = id;
            Department = department;
        }
    }
    private Queue<T> queue;

    public CustomQueue()
    {
        queue = new Queue<T>();
    }

    public Queue<T> Queue
    {
        get { return queue; }
    }

    // Перегрузка оператора + для добавления элемента в очередь
    public static CustomQueue<T> operator +(CustomQueue<T> customQueue, T item)
    {
        customQueue.queue.Enqueue(item);
        return customQueue;
    }

    // Перегрузка оператора -- для извлечения элемента из очереди
    public static CustomQueue<T> operator --(CustomQueue<T> customQueue)
    {
        customQueue.queue.Dequeue();
        return customQueue;
    }

    // Перегрузка оператора true для проверки, пустая ли очередь
    public static bool operator true(CustomQueue<T> customQueue)
    {
        return customQueue.queue.Count == 0;
    }

    public static bool operator false(CustomQueue<T> customQueue)
    {
        return customQueue.queue.Count > 0;
    }

    // Перегрузка оператора < для копирования и сортировки очереди в убывающем порядке
    public static CustomQueue<T> operator <(CustomQueue<T> customQueue1, CustomQueue<T> customQueue2)
    {
        var sortedQueue = new CustomQueue<T>();
        var sortedList = customQueue1.queue.OrderByDescending(x => x).ToList();
        foreach (var item in sortedList)
        {
            sortedQueue.queue.Enqueue(item);
        }
        return sortedQueue;
    }

    public static CustomQueue<T> operator > (CustomQueue<T> customQueue1, CustomQueue<T> customQueue2)
    {
        var sortedQueue = new CustomQueue<T>();
        var sortedList = customQueue1.queue.OrderBy(x => x).ToList();
        foreach (var item in sortedList)
        {
            sortedQueue.queue.Enqueue(item);
        }
        return sortedQueue;
    }
    // Неявное преобразование в int - мощность очереди
    public static implicit operator int(CustomQueue<T> customQueue)
    {
        return customQueue.queue.Count;
    }

    public static bool operator ==(CustomQueue<T> customQueue, bool value)
    {
        return (customQueue.queue.Count == 0) == value;
    }

    public static bool operator !=(CustomQueue<T> customQueue, bool value)
    {
        return (customQueue.queue.Count == 0) != value;
    }
}

// Необобщенный статический класс с методами расширения
public static class CustomQueueExtensions
{
    // Метод расширения: Индекс первой точки
    public static int FirstIndex(this CustomQueue<int> customQueue, int item)
    {
        return customQueue.Queue.ToList().IndexOf(item);
    }

    // Метод расширения: Последний элемент очереди
    public static int LastElement(this CustomQueue<int> customQueue)
    {
        return customQueue.Queue.LastOrDefault();
    }
}
static class StatisticOperation
{
    // Метод для вычисления суммы элементов в очереди
    public static int Sum(CustomQueue<int> customQueue)
    {
        return customQueue.Queue.Sum();
    }

    // Метод для вычисления разницы между максимальным и минимальным элементами в очереди
    public static int Difference(CustomQueue<int> customQueue)
    {
        if (customQueue.Queue.Count == 0)
            return 0;

        int max = customQueue.Queue.Max();
        int min = customQueue.Queue.Min();
        return max - min;
    }

    // Метод для подсчета количества элементов в очереди
    public static int Count(CustomQueue<int> customQueue)
    {
        return customQueue.Queue.Count;
    }

    // Метод расширения для типа string: получение длины строки
    public static int Length(this string str)
    {
        return str.Length;
    }

    // Метод расширения для CustomQueue<string>: подсчет количества строк в очереди
    public static int CountLines(this CustomQueue<string> customQueue)
    {
        return customQueue.Queue.Count;
    }
}

class Program
{
    static void Main()
    {
        CustomQueue<int> customQueue1 = new CustomQueue<int>();
        customQueue1 = customQueue1 + 5;
        customQueue1 = customQueue1 + 10;
        customQueue1 = customQueue1 + 3;
        customQueue1--;

        CustomQueue<int> customQueue2 = new CustomQueue<int>();
        customQueue2 = customQueue2 + 7;
        customQueue2 = customQueue2 + 1;

        customQueue1 = customQueue1 < customQueue2;

        Console.WriteLine("Queue Count: " + (int)customQueue1);
        Console.WriteLine("First Index of 10: " + customQueue1.FirstIndex(10));
        Console.WriteLine("Last Element: " + customQueue1.LastElement());


        Console.WriteLine("Is Queue Empty? " + (customQueue1 == true));

/////////////////////////////////////////////////////////////////////////////////////////

        Console.WriteLine("Sum: " + StatisticOperation.Sum(customQueue1));
        Console.WriteLine("Difference: " + StatisticOperation.Difference(customQueue1));
        Console.WriteLine("Count: " + StatisticOperation.Count(customQueue1));

        string str = "Hello, World!";
        Console.WriteLine("String Length: " + str.Length);

        CustomQueue<string> stringQueue = new CustomQueue<string>();
        stringQueue = stringQueue + "Line 1";
        stringQueue = stringQueue + "Line 2";
        Console.WriteLine("String Queue Count: " + stringQueue.CountLines());

    }
}
