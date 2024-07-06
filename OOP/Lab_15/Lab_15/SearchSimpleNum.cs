using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_15
{
    public static class SearchSimpleNum
    {
        public static void ReshetoEratosfena(int n)
        {
            int[] arr = new int[n];
            arr[0] = 0; // 1 - не простое число
                        // заполняем решето единицами

            for (int k = 1; k < n; k++)
                arr[k] = 1;

            for (int k = 2; k * k < n; k++)
            {
                // если k - простое (не вычеркнуто)
                if (arr[k] == 1)
                {
                    // то вычеркнем кратные k
                    for (int l = k * k; l < n; l += k)
                    {
                        arr[l] = 0;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                Thread.Sleep(100);
                if (arr[i] == 1)
                    Console.WriteLine(i);
            }
        }
        public static void ReshetoEratosfenaToken(int n, CancellationToken token)
        {
            int[] arr = new int[n];
            arr[0] = 0; // 1 - не простое число
                        // заполняем решето единицами

            for (int k = 1; k < n; k++)
                arr[k] = 1;

            for (int k = 2; k * k < n && !token.IsCancellationRequested; k++)
            {
                // если k - простое (не вычеркнуто)
                if (arr[k] == 1)
                {
                    // то вычеркнем кратные k
                    for (int l = k * k; l < n; l += k)
                    {
                        arr[l] = 0;
                    }
                }
            }

            for (int i = 0; i < n && !token.IsCancellationRequested; i++)
            {
                Thread.Sleep(200);
                if (arr[i] == 1)
                    Console.WriteLine(i);
            }
        }
    }
}
