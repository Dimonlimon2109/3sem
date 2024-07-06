using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_07
{
    public class CustomQueue<T> : IItems<T>
    {
        private Queue<T> queue;

        public int Count => queue.Count; //размерность
        public CustomQueue()
        {
            queue = new Queue<T>();
        }

        public Queue<T> Queue
        {
            get { return queue; }
        }
        public CustomQueue(params T[] items)
        {
            queue = new Queue<T>();
            foreach (T item in items)
            {
                queue.Enqueue(item);
            }
        }
        public void Add(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("передана пустая переменная!");
            }
            queue.Enqueue(value);
        }
        public void Delete()
        {
            if (queue.Count == 0)
            {
                throw new InvalidOperationException("Очередь пуста!");
            }
            queue.Dequeue();
        }
        public void Print(string message)
        {
            Console.Write(message + "\t\t");
            foreach (T item in queue)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();

        }

        public void Print()
        {

            foreach (T item in queue)
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }

        public void ToFile(string path)
        {
            using (StreamWriter writer = new(path, false))
            {
                foreach (T item in queue)
                {
                    writer.Write(item);
                }
                Console.WriteLine("Файл записан!");
            }
        }

        public void FromFile(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string? line;

                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
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

        public static CustomQueue<T> operator >(CustomQueue<T> customQueue1, CustomQueue<T> customQueue2)
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
}
