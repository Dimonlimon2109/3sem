using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_14
{
    static class GetProcess
    {
        public static void GetAllProcesses()
        {

            var Processes = Process.GetCurrentProcess();
            Console.WriteLine("Текущий процесс:");
            Console.WriteLine($"ID: {Processes.Id}, Имя: {Processes.ProcessName}, Приоритет: {Processes.BasePriority}, Время запуска: {Processes.StartTime}, Время использования: {Processes.UserProcessorTime}");
            Console.WriteLine("Все запущенные процессы:");
            foreach (var process in Process.GetProcesses())
            {
                try
                {
                    Console.WriteLine($"ID: {process.Id}, Имя: {process.ProcessName}, Приоритет: {process.BasePriority}, Время запуска: {process.StartTime}, Время использования: {process.UserProcessorTime}, Работает?: {process.Responding}");
                }
                catch(Exception ex) {
                    Console.WriteLine(ex.Message);
                }
                }
        }
    }
}
