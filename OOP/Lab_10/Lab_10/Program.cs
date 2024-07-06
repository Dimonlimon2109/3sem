using System;

namespace Lab_10
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("TASK 1: ");
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            Console.WriteLine("Введите число n");
            int n = Convert.ToInt32(Console.ReadLine());
            IEnumerable<string> result = months
                .Where(s => s.Length == n)
                .Select(s => s);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            result = months
                .Where(s => s == "December" || s == "January" || s == "February" || s == "June" || s == "July" || s == "August")
                .Select(s => s);
            Console.WriteLine("Летние и зимние месяцы: ");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            result = months
                .OrderBy(s => s)
                .Select(s => s);
            Console.WriteLine("Месяца в алфавитном порядке: ");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            int u = months
                .Where(s => s.Contains("u") && s.Length >= 4)
                .Count();
            Console.WriteLine("Месяца с буквой u и размером 4 и более: " + u);
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("TASK 2");
            List<Stack> stacks = new List<Stack>();
            stacks.Add(new Stack(1.1, 2.2, 3.3));
            stacks.Add(new Stack(6.66));
            stacks.Add(new Stack(2.9, 8.77, 0, 3.22));
            stacks.Add(new Stack(12.1, -3.9, 5.55));
            stacks.Add(new Stack(-1.1, 3.4, 5.4));
            stacks.Add(new Stack(7.77, 0, 1.11));
            stacks.Add(new Stack(2.8));
            stacks.Add(new Stack(5.55, 77.7, 11.1111111, 9.77));
            Console.WriteLine("Все стеки:");
            foreach (var item in stacks)
            {
                Console.WriteLine(item);
            }
            var stackWithMinTopElement = stacks.OrderBy(stack => stack.stack.Last()).FirstOrDefault();
            Console.WriteLine($"Стек с минимальным верхним элементом{stackWithMinTopElement.ToString()}");
            var stackWithMaxTopElement = stacks.OrderByDescending(stack => stack.stack.Last()).FirstOrDefault();
            Console.WriteLine($"Стек с максимальным верхним элементом{stackWithMaxTopElement.ToString()}");
            var stackWithNegative = stacks.Where(stack => stack.stack.Any(elem => elem < 0)).ToList();
            Console.WriteLine("Стеки, содержащие отрицательные элементы: ");
            foreach(var item in stackWithNegative)
            {
                Console.WriteLine(item);
            }
            var minSizeStack = stacks.OrderBy(stack => stack.stack.Count).First();
            Console.WriteLine($"Стек с минимальным количеством элементов: {minSizeStack}");
            var stacksWithLength1or3 = stacks.Where(stack => stack.stack.Count == 3 || stack.stack.Count == 1).ToArray();
            Console.WriteLine("Стеки длинной 1 и 3");
            foreach (var item in stacksWithLength1or3)
            {
                Console.WriteLine(item);
            }
            var firstStackWith0 = stacks.First(stack => stack.stack.Any(element => element == 0));
            Console.WriteLine($"Первый стек в списке с нулевым значением: {firstStackWith0}");  
            var sortedStacks = stacks.OrderBy(stack => stack.stack.Sum()).ToList();
            Console.WriteLine("Упорядоченный массив стеков по сумме элементов");
            foreach (var stack in sortedStacks)
            {
                Console.WriteLine(stack);
            }
            var customFilter = stacks
                .Where(stack => stack.stack.Any(element => element != 0))
                .OrderBy(stack => stack.stack.Sum())
                .GroupBy(stack => stack.stack.Count % 2 == 0);
            Console.WriteLine("Стеки, не содержащие нули, отсортированные по возрастанию и поделенные на группы");
            foreach (var stack in customFilter)
            {
                Console.WriteLine(stack.Key + " " + stack.Count());
                foreach (var m in stack)
                {
                    Console.WriteLine(m);
                }
            }
            int[] doubleArrays = new int[] { 3, 4};
            var joinedStacks = stacks
    .Join(
        doubleArrays,
        stack => stack.stack.Count, // Ключ в первой последовательности (количество элементов в стеке)
        value => value, // Ключ во второй последовательности (значение из массива)
        (stack, value) => new { Stack = stack, Value = value } // Результат объединения
);
            Console.WriteLine("Использование запроса Join: ");
            foreach (var item in joinedStacks)
            {
                Console.WriteLine($"Stack: {string.Join(", ", item.Stack.stack)} | Value: {item.Value}");
            }
        }
    }
}