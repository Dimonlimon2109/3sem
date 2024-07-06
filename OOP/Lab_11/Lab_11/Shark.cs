using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_11
{
    interface Foo
    {
        public int MyMethods(int a, double b);
    }
    public sealed class Shark : Foo
    {
        private void FOO()
        {
            Console.WriteLine("Приватный метод класса Shark");
        }
        public string name { get; set; }
        public double weight { get; set; }

        public ushort birthYear { get; set; }
        public Shark(string name, double weight, ushort birthYear)
        {
            this.name = name;
            this.weight = weight;
            this.birthYear = birthYear;
        }
        public Shark()
        {

        }
        public void Swim(int b)
        {
            Console.WriteLine("Акула плывет со скоростью 19 км/ч");
        }
        public void MakeSound(string a)
        {
            Console.WriteLine("*Вибрация*");
        }
        public void Method (object c) {
            Console.WriteLine(c);
        }
        public int MyMethods(int a, double b)
        {
            Console.WriteLine("\nФункция MyMethods вызвана!");
            return a + (int)b;
        }
    }
}
