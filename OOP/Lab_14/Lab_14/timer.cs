using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_14
{
    public class timer
    {
        public static void Output(object v)
        {
            Console.WriteLine();
            Console.WriteLine("Max INT: " + int.MaxValue);
            Console.WriteLine("Min INT: " + int.MinValue);
            Console.WriteLine("Size INT: " + sizeof(int));
        }

        public static void _timer()
        {
            Thread.Sleep(20);
            TimerCallback tm = new TimerCallback(Output);
            Timer timer = new(tm, null, 0, 100);

        }
    }
}
