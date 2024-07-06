using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_15
{
    public static class Trade
    {
        static BlockingCollection<string> warehouse = new BlockingCollection<string>();

        public static async Task TradeAsync()
        {
            // Поставщики товаров
            Task[] suppliers = new Task[5];
            for (int i = 0; i < suppliers.Length; i++)
            {
                suppliers[i] = Task.Run(() => Supplier(i + 1));
            }

            // Покупатели
            Task[] customers = new Task[10];
            for (int i = 0; i < customers.Length; i++)
            {
                customers[i] = Task.Run(() => Customer(i + 1));
            }

            // Ждем завершения всех задач
            await Task.WhenAll(suppliers);
            await Task.WhenAll(customers);
        }

        static void Supplier(int supplierId)
        {
            Random random = new Random();

            while (true)
            {
                // Создаем уникальный товар
                string item = $"Товар от Поставщика {supplierId}";

                // Задержка для имитации времени на доставку
                int delay = random.Next(1000, 3000);
                Thread.Sleep(delay);

                // Добавляем товар на склад
                warehouse.Add(item);
                Console.WriteLine($"Поставщик {supplierId} добавил {item}. Склад: {string.Join(", ", warehouse)}");
            }
        }

        static void Customer(int customerId)
        {
            Random random = new Random();

            while (true)
            {
                // Задержка для имитации времени на принятие решения о покупке
                Thread.Sleep(random.Next(500, 2000));

                // Покупатель пытается купить товар
                string item;
                if (warehouse.TryTake(out item))
                {
                    Console.WriteLine($"Покупатель {customerId} купил {item}. Склад: {string.Join(", ", warehouse)}");
                }
                else
                {
                    Console.WriteLine($"Покупатель {customerId} ушел. Нет доступных товаров. Склад:  {string.Join(", ", warehouse)}");
                    return;
                }
            }
        }
    }
}