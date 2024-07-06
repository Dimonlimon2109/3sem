using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_15
{
    static public class LongArray
    {
        static int numberOfArrays = 3;
        static int arrSize = 1000000;
        static public int[][] GenerateArrayParallel()
        {
            int[][] arrays = new int[numberOfArrays][];
            Parallel.For(0, numberOfArrays, i =>
            {
                arrays[i] = GenerateArray();
            });
            return arrays;

        }
        static int[] GenerateArray()
        {
            Random rnd = new Random();
            int[] array = new int[arrSize];
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(0, 9);
            }
            return array;
        }
    }
}
