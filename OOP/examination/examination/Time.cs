using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examination
{
    internal class Time
    {
        private int hour;
        public int Hour
        {
            get { return hour; }
            set { 
                if(hour < 0) {
                    hour = 0;
                }
                if(hour > 23)
                {
                    hour = 23;
                }
                hour = value; }
        }
        private int minute;
        public int Minute
        {
            get { return minute; }
            set
            {
                if (minute < 0)
                {
                    minute = 0;
                }
                if (minute > 59)
                {
                    minute = 59;
                }
                hour = value;
            }
        }
        private int second;
        public int Second
        {
            get { return second; }
            set
            {
                if (second < 0)
                {
                    second = 0;
                }
                if (second > 59)
                {
                    second = 59;
                }
                second = value;
            }
        }
        public Time() {
            hour = 0;
            minute = 0;
            second = 0;
        }
        public Time(int hour, int minute, int second)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }
        public void Print()
        {
            Console.WriteLine($"{hour} часов {minute} минуты, {second} секунды");
        }

        public override string ToString()
        {
            return $"{hour}:{minute}:{second}";
        }
        public override bool Equals(object? obj)
        {
            Time time = obj as Time;
            if(time.hour == this.hour && time.minute == this.minute && this.second == time.second)
                return true;
            return false;

        }
        public static bool operator >(Time time1, Time time2)
        {
            if (time1.hour > time2.hour)
            {
                return true;
            }
            else if(time1.hour < time2.hour)
            { return false; }
            if (time1.hour == time2.hour && time1.minute > time2.minute)
            {
                return true;
            }
            else if (time1.minute < time2.minute) { return false; }
            if (time1.hour == time2.hour && time1.minute == time2.minute && time1.second > time2.second)
            {
                return true;
            }
            else if (time1.second < time2.second) { return false; }
            return false;
        }
        public static bool operator <(Time time1, Time time2)
        {
            if (time1.hour < time2.hour)
            {
                return true;
            }
            else if (time1.hour > time2.hour)
            { return false; }
            if (time1.hour == time2.hour && time1.minute < time2.minute)
            {
                return true;
            }
            else if (time1.minute > time2.minute) { return false; }
            if (time1.hour == time2.hour && time1.minute == time2.minute && time1.second < time2.second)
            {
                return true;
            }
            else if (time1.second > time2.second) { return false; }
            return false;
        }
    }
}
