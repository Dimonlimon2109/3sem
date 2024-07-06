using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal static class Director
    {
        public static void CreateExample()
        {
            Dispatcher dispatcher = Dispatcher.GetInstance();
            Builder.CreateTenant();
            Tenant tenant1 = (Tenant)Builder.GetResult();
            tenant1.MakeApplication();
            Builder.CloneTenant(tenant1);
            Tenant tenant2 = (Tenant)Builder.GetResult();
            tenant2.MakeApplication();
            dispatcher.AddBrigade();
        }
    }

    internal static class Builder
    {
        private static object? result;
        public static void CreateTenant()
        {
            IPeopleFactory factory;
            factory = new TenantFactory();
            Tenant client1 = (Tenant)factory.CreatePerson("Артур", "Пирожков", "+375336862484");
            result = client1;
        }
        public static void CreateDispatcher()
        {
            IPeopleFactory factory = new TenantFactory();
            Dispatcher dispatcher = (Dispatcher)factory.CreatePerson("Наполеон", "Великий", "+375299275702");
        }
        public static void CloneTenant(Tenant client)
        {
            result = client.Clone();
        }
        public static object GetResult()
        {
            return result;
        }
    }
}
