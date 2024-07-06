using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_07
{
    public class Parrot
    {
        public string name { get; set; }
        public double weight { get; set; }

        public ushort birthYear {  get; set; }
        public Parrot(string name, double weight, ushort birthYear)
        {
            this.name = name;
            this.weight = weight;
            this.birthYear = birthYear;
        }
        public override string ToString()
        {
            return $"Вид: {GetType().Name}, Имя: {name}, Год рождения: {birthYear}, Вес: {weight} кг.\n";
        }
    }
}
