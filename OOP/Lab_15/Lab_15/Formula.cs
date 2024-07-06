using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_15
{
        public static class Formula
        {
            public static int _pow(int a, int n)
            {
                for (int i = 1; i < n; i++)
                {
                    a *= a;
                }
                return a;
            }

            public static void _powOutput(int a, int n)
            {
                Console.WriteLine($"Число {a} в степени {n}: " + _pow(a, n));
            }

            public static int _sum(params int[] num)
            {
                int sum = 0;
                foreach (int i in num)
                {
                    sum += i;
                }
                return sum;
            }

            public static void _sumOutput(params int[] num)
            {
                Console.WriteLine($"Сумма: " + _sum(num));
            }

            public static int _mul(params int[] num)
            {
                int mul = 1;
                foreach (int i in num)
                {
                    mul *= i;
                }
                return mul;
            }

            public static void _mulOutput(params int[] num)
            {
                Console.WriteLine("Произведение: " + _mul(num));
            }
        }
}
