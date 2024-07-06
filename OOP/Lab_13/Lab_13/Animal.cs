using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_13
{
    [Serializable]
    public abstract class Animal
    {
        public ushort year_of_birth { get; set; }
        public double kg_weight { get; set; }
        public string Name { get; set; }
        public abstract void MakeSound();

        public abstract bool IsHunt();
        public override string ToString()
        {
            return $"Вид: {GetType().Name}, Имя: {Name}, Год рождения: {year_of_birth}, Вес: {kg_weight} кг";
        }
        public Animal(string name, double weight, ushort birthYear)
        {
            Name = name;
            kg_weight = weight;
            year_of_birth = birthYear;
        }
        public Animal()
        {

        }
    }

}
