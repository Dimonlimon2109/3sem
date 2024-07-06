using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab_14
{
    static class Domain
    {
        public static void GetDomainInfo()
        {
            var domain = AppDomain.CurrentDomain;
            Console.WriteLine("Текущий домен:");
            Console.WriteLine($"Имя: {domain.FriendlyName}");
            Console.WriteLine($"Базовый директорий: {domain.BaseDirectory}");
            Console.WriteLine($"Текущяя конфигурация: {domain.SetupInformation}");
            Console.WriteLine("Все сборки:");
            Assembly[] assemblies = domain.GetAssemblies();
            foreach (Assembly asm in assemblies)
            {
                Console.WriteLine(asm.GetName().Name);
            }
        }
        public static void CreateDomain()
        {
            try
            {
                AppDomain newDomain = AppDomain.CreateDomain("NewDomain");
                newDomain.Load(newDomain.BaseDirectory);
                Console.WriteLine($"Новый домен: {newDomain.FriendlyName}");
                AppDomain.Unload(newDomain);
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
