using System;
using System.Security.Cryptography.X509Certificates;

namespace ControlWorking
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("-----------------------------1a--------------------------");
            Console.WriteLine("Введите строку");
            string str = Console.ReadLine();
            Console.WriteLine(str + str.Last());
            Console.WriteLine("-----------------------------1b--------------------------");
            Random random = new Random();
            int pozitive = 0;
            int[][] mas = new int[5][];
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = new int[5];
                for (int j = 0; j < mas[i].Length; j++)
                {
                    mas[i][j] = random.Next(-10, 10);
                    Console.Write(mas[i][j] + ", ");
                    if (mas[i][j] > 0)
                        pozitive++;

                }
                Console.WriteLine("\n");
            }
            Console.WriteLine($"Количество положительных элементов массива: {pozitive}");
            Console.WriteLine("-----------------------------2--------------------------");
            MyCollection<int> myCollInt = new MyCollection<int>();
            MyCollection<double> myCollDouble = new MyCollection<double>();
            try
            {
                myCollInt.Add(3);
                myCollInt.Add(4);
                myCollInt.Add(5);
                myCollInt.Find(4);
                myCollDouble.Add(3.2);
                myCollDouble.Add(7.8);
                myCollDouble.Add(10.8);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("-----------------------------3--------------------------");
            List<char> list = new List<char> { 'z', 'r', 'a', 't', 'e', 'r', 'w', 'q'};
            var sortedList = list.OrderBy(x => x).Distinct();
            int count = 0;
            Console.WriteLine();
            foreach (char c in sortedList)
            { Console.WriteLine(c); }
            foreach(var x in sortedList)
            {
                if (count < 3 || count >= sortedList.Count() - 2)
                {
                    Console.Write(x);
                }
                count++;
            }
            Console.WriteLine("-----------------------------4--------------------------");
        }
    }
}
