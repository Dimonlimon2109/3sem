using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examination
{

    public enum toplivoType
    {
        benzin,
        energy
    }
    public abstract class Transport
    { 
        public int speed {  get; set; }
        public toplivoType toplivo { get; set; }

        public int year {  get; set; }

        public abstract void Go();
        public Transport(int speed, toplivoType toplivo, int year)
        {
            this.speed = speed;
            this.toplivo = toplivo;
            this.year = year;
        }
    }

    public class Car : Transport
    { 
        public int id {  get; set; }
        public string mark { get; set; }

        public Car(int speed, toplivoType toplivo, int year, int id, string mark):base(speed, toplivo, year)
        {
            this.id = id;
            this.mark = mark;
        }

        public override void Go()
        {
            Console.WriteLine("Машина едет по трассе");
        }
        public override string ToString()
        {
            return $"{mark}, {id}, {year}, {toplivo}, {speed}";
        }
    }
    public class Train : Transport
    { 
        public int id { get; set; }
        public int vagonNumber {  get; set; }
        public int peopleNumber { get; set; }

        public Train (int speed, toplivoType toplivo, int year, int id, int peopleNumber, int vagonNumber) : base(speed, toplivo, year)
        {
            this.id = id;
            this.vagonNumber = vagonNumber;
            this.peopleNumber = peopleNumber;
        }
        public override void Go()
        {
            Console.WriteLine("Поезд движется по рельсовым путям");
        }
    }
}
