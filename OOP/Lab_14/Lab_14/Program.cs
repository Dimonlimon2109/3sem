using System;

namespace Lab_14
{
    class Program
    {
        static void Main(string[] args)
        {/////////////////1
            GetProcess.GetAllProcesses();
            /////////////////2
            Domain.GetDomainInfo();
            Domain.CreateDomain();
            ////////////////////3
            Console.WriteLine("Введите значение n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            NewThread.CreateThread(n);
            int k = Convert.ToInt32(Console.ReadLine());
            TwoThread.CreateThreadi(k);
            TwoThread.CreateThreadii(k);
            timer._timer();
            Console.WriteLine("Таймер запущен. Нажмите Enter для завершения.");
            Console.ReadLine();
        }
    }
}