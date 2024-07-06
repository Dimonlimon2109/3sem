using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_09
{
    public class Conserts
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public Conserts(string name, int price)
        {
            Name = name;
            Price = price;
        }
        public override string ToString()
        {
            return $"Name: {Name}, Price: {Price}";
        }
    }
}
