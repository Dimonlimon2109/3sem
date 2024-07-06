using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IPeopleFactory
    {
        public Person CreatePerson(string name, string surname, string phone);
    }
    public class TenantFactory : IPeopleFactory
    {
        public Person CreatePerson(string name, string surname, string phone)
        {
            return new Tenant(name, surname, phone);
        }
    }
    public class DispatcherFactory : IPeopleFactory
    {
        public Person CreatePerson(string name, string surname, string phone)
        {
            return new Dispatcher(name, surname, phone);
        }
    }

}
