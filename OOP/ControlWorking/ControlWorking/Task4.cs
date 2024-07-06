using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorking
{
    public delegate void del();
    public class NewsChannel
    {
        public string name { get; set; }
        public int number { get; set; }

        public static event del Notify;
        public NewsChannel(string Name, int Number) {
            
            name = Name;
            number = Number;
        }

        public void PublishingNews(string message)
        {
            Console.WriteLine(message);

        }
    }

    public class Subscriber
    {
        public Subscriber(string Name, int Id) { 
            name =Name;
           id = Id;
        }
        public string name { get; set; }
        public int id { get; set; }
        public void ReadingNews() {
            Console.WriteLine("Подписчик " + name + " читает новость");
        }
    }
}
