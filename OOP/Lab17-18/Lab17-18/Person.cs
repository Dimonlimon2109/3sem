using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class Person
    {
        public string name;
        public string surname;
        public string phone;

        public Person()
        {

        }
        public Person(string name, string surname, string phone)
        {
            this.name = name;
            this.surname = surname;
            this.phone = phone;
        }
    }
    internal class Tenant : Person
    {
        public Application application;

        public Tenant(string name, string surname, string phone) : base(name, surname, phone)
        {
            this.application = new Application();
        }

        private Tenant(Tenant client)
        {
            this.name = client.name;
            this.surname = client.surname;
            this.phone = client.phone;
            this.application = new Application();
        }

        public void MakeApplication()
        {
            this.application = new Application("Ремонт", "Тяжёлая", DateTime.Now.AddDays(7));
        }
        public Person Clone()
        {
            return new Tenant(this);
        }

    }
}
