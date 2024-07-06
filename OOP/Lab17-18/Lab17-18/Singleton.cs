using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    public class Dispatcher : Person
    {
        private static Dispatcher? instance = null;
        private static readonly object threadlock = new object();
        public static List<Brigade> Plan_of_work;
        public Dispatcher(string name, string surname, string phone) : base(name, surname, phone)
        {
            Plan_of_work = new List<Brigade>();
        }
        public static Dispatcher GetInstance()
        {
            lock (threadlock)
            {
                if (instance == null)
                {
                    instance = new Dispatcher("Дмитрий", "Бублик", "+375299275702");
                }
                return instance;
            }
        }

        public void AddBrigade()
        {
            Brigade brigade = new Brigade("Чинилы", 5, "Ремонт", "+375299275702");
            Plan_of_work.Add(brigade);
        }
        public class Brigade
        {
            private string name;
            private int number_of_workers;
            private string specialization;
            private string number;
            public Brigade()
            {

            }
            public Brigade(string name, int number_of_workers, string specialization, string number)
            {
                this.name = name;
                this.number_of_workers = number_of_workers;
                this.specialization = specialization;
                this.number = number;
            }
        }
    }
}
