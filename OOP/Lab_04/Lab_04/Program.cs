using System;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

public interface IAnimal
{
    double kg_weight { get; set; }
    string Name { get; set; }

    public ushort year_of_birth { get; set; }
    void MakeSound();

}

public interface IHunt
{ bool IsHunt(); 
}


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
}

public abstract class Reptile: Animal, IAnimal
{
    public Reptile(string name, double weight, ushort birthYear) : base(name, weight, birthYear)
    {
    }
    public abstract void Crawl();
}


public abstract class Mammal:Animal, IAnimal
{
    public Mammal(string name, double weight, ushort birthYear) : base(name, weight, birthYear)
    {
    }
    public abstract void Run();
}

public abstract class Bird:Animal, IAnimal
{
    public Bird(string name, double weight, ushort birthYear) : base(name, weight, birthYear)
    {
    }
    public abstract void Fly();
}

public abstract class Fish : Animal, IAnimal {

    public Fish(string name, double weight, ushort birthYear) : base(name, weight, birthYear)
    {
    }
    public abstract void Swim();
}

public sealed class Crocodile : Reptile, IHunt
{
    public Crocodile(string name, double weight, ushort birthYear) : base(name, weight, birthYear)
    {
    }
    public override void Crawl()
    {
        Console.WriteLine("Крокодил ползёт со скоростью 2 км/ч");
    }
    public override void MakeSound()
    {
        Console.WriteLine("Шшшшшш!");
    }

    public override bool IsHunt()
    {
        Console.WriteLine("Крокодил - хищник (из абстрактного класса Animal)");
        return true;
    }

    bool IHunt.IsHunt()
    {
        Console.WriteLine("Крокодил - хищник (из интерфейса Hunt)");
        return true;
    }
}
public sealed class Lion:Mammal {
    public Lion(string name, double weight, ushort birthYear) : base(name, weight, birthYear)
    {
    }
    public override void Run()
    {
        Console.WriteLine("Лев бежит со скоростью 74 км/ч");
    }
    public override void MakeSound()
    {
        Console.WriteLine("Грррр!");
    }
    public override bool IsHunt()
    {
        Console.WriteLine("Лев - хищник");
        return true;
    }
}
public sealed class Tiger:Mammal {

    public Tiger(string name, double weight, ushort birthYear) : base(name, weight, birthYear)
    {
    }
    public override void Run()
    {
        Console.WriteLine("Тигр бежит со скоростью 65 км/ч");
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

public sealed class Shark : Fish
{
    public Shark(string name, double weight, ushort birthYear) : base(name, weight, birthYear)
    {
    }
    public override void Swim()
    {
        Console.WriteLine("Акула плывет со скоростью 19 км/ч");
    }
    public override void MakeSound()
    {
        Console.WriteLine("*Вибрация*");
    }
    public override bool IsHunt()
    {
        Console.WriteLine("Акула - хищник");
        return true;
    }
}
public sealed class Owl : Bird {

    public Owl(string name, double weight, ushort birthYear) : base(name, weight, birthYear)
    {
    }
    public override void Fly()
    {
        Console.WriteLine("Сова летит за жертвой!");
    }
    public override void MakeSound()
    {
        Console.WriteLine("Ху-ху!");
    }
            public override bool IsHunt()
    {
        Console.WriteLine("Сова - хищник");
        return true;
    }
}
public sealed class Parrot : Bird {
    public Parrot(string name, double weight, ushort birthYear) : base(name, weight, birthYear)
    {
    }
    public override void Fly()
    {
        Console.WriteLine("Попугай летит!");
    }
    public override void MakeSound()
    {
        Console.WriteLine("*Оскорбления в сторону хозяина*");
    }
    public override bool IsHunt()
    {
        Console.WriteLine("Попугай - травоядный");
        return false;
    }
}

public class Printer
{
    public void IAmPrinting(Animal someObj)
    {
        Console.WriteLine(someObj.ToString());
    }
}

class Program
{
    static void Main()
    {
        Animal lion = new Lion("Simba", 190, 1999);
        Animal owl = new Owl("Hedwig", 0.2, 2010);
        Animal tiger = new Tiger("Rajah", 250, 2005);
        Animal crocodile = new Crocodile("Croc", 400, 1990);
        Animal shark = new Shark("Jaws", 1000, 1979);
        Animal parrot = new Parrot("Polly", 0.456, 2020);

        crocodile.IsHunt();
        ((IHunt)crocodile).IsHunt();
        // Используем оператор is для проверки типов объектов
        if (lion is Animal)
        {  
            Console.WriteLine("Лев это животное");
        }

        // Используем оператор as для приведения типов объектов
        Animal tigerAsAnimal = tiger as Animal;
        if (tigerAsAnimal != null)
        {
            Console.WriteLine($"tiger это {tigerAsAnimal.GetType().Name}.");
        }

        Printer printer = new Printer();
        Animal[] animals = { lion, owl, tiger, crocodile, shark, parrot };

        foreach (var animal in animals)
        {
            printer.IAmPrinting(animal);
            animal.MakeSound();
            Console.WriteLine();
        }
    }
}