using System;
using System.Net.WebSockets;
using examination;
class Program
{ 
static void Main()
    {
        Time time1 = new Time(16, 18, 3);
        Time time2 = new Time(16, 18, 3);
        Time time3 = new Time(23, 58, 16);
        time1.Print();
        Console.WriteLine(time2.ToString());
        time1.Equals(time2);
        if(time3 > time1)
        {
            time3.Print();
        }
        else if(!(time3 < time1))
        {
            time1.Print();
        }
        time1.Hour = 15;
        Console.WriteLine(time1.ToString());

        Car car1 = new Car(120, toplivoType.benzin, 1970, 10, "Ferrari");
        Car car2 = new Car(200, toplivoType.benzin, 2005, 8, "BMW");
        Car car3 = new Car(250, toplivoType.energy, 2023, 1, "TESLA");
        Car car4 = new Car(300, toplivoType.benzin, 2012, 11, "Ferrari");
        List<Car> cars = new List<Car>();
        cars.Add(car1);
        cars.Add(car2);
        cars.Add(car3);
        cars.Add(car4);
        car1.Go();
        Train train1 = new Train(300, toplivoType.energy, 1960, 322, 8, 300);
        var sortedCars = cars.Where(car => car.mark == "Ferrari");
        foreach(Car car in sortedCars)
        {
            Console.WriteLine(car);
        }
    }
}