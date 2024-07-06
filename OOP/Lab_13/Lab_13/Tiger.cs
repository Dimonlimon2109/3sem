using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_13
{
    [Serializable]
    public sealed class Tiger : Animal
    {

        public Tiger(string name, double weight, ushort birthYear, ushort height) : base(name, weight, birthYear)
        {
            _height = height;
        }
        public Tiger()
        {

        }
        public void Run()
        {
            Console.WriteLine("Тигр бежит со скоростью 65 км/ч");
        }

        [NonSerialized]
        private ushort height;
        public ushort _height
        {
            get { return height; }
            set { height = value; }
        }
        public override void MakeSound()
        {
            Console.WriteLine("РРРРРРР!");
        }
        public override bool IsHunt()
        {
            Console.WriteLine("Тигр - хищник");
            return true;
        }
    }
}
