using Lab_05;
using System;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace Lab_05
{
    public enum AnimalType
    {
        Reptile,
        Mammal,
        Bird,
        Fish
    }

    public struct AnimalInfo
    {
        public string Habitat { get; set; }
        public string ConservationStatus { get; set; }
    }
    public interface IAnimal
    {
        double kg_weight { get; set; }
        string Name { get; set; }

        public ushort year_of_birth { get; set; }
        void MakeSound();

    }


    public abstract class Animal
    {
        public ushort year_of_birth { get; set; }
        public double kg_weight { get; set; }
        public string Name { get; set; }
        public abstract void MakeSound();
        public AnimalInfo Info { get; set; } // Добавлено поле Info

        public abstract bool IsHunt();
        public override string ToString()
        {
            return $"Вид: {GetType().Name}, Имя: {Name}, Год рождения: {year_of_birth}, Вес: {kg_weight} кг\nМесто обитания: {Info.Habitat}, Статус охраны: {Info.ConservationStatus}";
        }
        public Animal(string name, double weight, ushort birthYear, AnimalInfo info)
        {
            Name = name;
            kg_weight = weight;
            year_of_birth = birthYear;
            Info = info;
        }
    }

    public abstract class Reptile : Animal, IAnimal
    {
        public Reptile(string name, double weight, ushort birthYear, AnimalInfo info) : base(name, weight, birthYear, info)
        {
        }
        public abstract void Crawl();
    }


    public abstract class Mammal : Animal, IAnimal
    {
        public Mammal(string name, double weight, ushort birthYear, AnimalInfo info) : base(name, weight, birthYear, info)
        {
        }
        public abstract void Run();
    }

    public abstract class Bird : Animal, IAnimal
    {
        public Bird(string name, double weight, ushort birthYear, AnimalInfo info) : base(name, weight, birthYear, info)
        {
        }
        public abstract void Fly();
    }

    public abstract class Fish : Animal, IAnimal
    {

        public Fish(string name, double weight, ushort birthYear, AnimalInfo info) : base(name, weight, birthYear, info)
        {
        }
        public abstract void Swim();
    }

    public sealed partial class Crocodile : Reptile
    {
        public Crocodile(string name, double weight, ushort birthYear) : base(name, weight, birthYear, new AnimalInfo
        {
            Habitat = "Тропические реки и болота",
            ConservationStatus = "Мало охраняемый"
        })
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
    }
    public sealed class Lion : Mammal
    {
        public Lion(string name, double weight, ushort birthYear) : base(name, weight, birthYear, new AnimalInfo
        {
            Habitat = "Саванна",
            ConservationStatus = "Уязвимый"
        })
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
            return true;
        }
    }
    public sealed class Tiger : Mammal
    {
    public Tiger(string name, double weight, ushort birthYear) : base(name, weight, birthYear, new AnimalInfo
    {
        Habitat = "Саванна",
        ConservationStatus = "Умеренно охраняемый"
    })
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
            return true;
        }
    }

    public sealed class Shark : Fish
    {
    public Shark(string name, double weight, ushort birthYear) : base(name, weight, birthYear, new AnimalInfo
    {
        Habitat = "Океан",
        ConservationStatus = "Умеренно охраняемый"
    })
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
            return true;
        }
    }
    public sealed class Owl : Bird
    {
    public Owl(string name, double weight, ushort birthYear) : base(name, weight, birthYear, new AnimalInfo
    {
        Habitat = "Лес",
        ConservationStatus = "Мало охраняемый"
    })
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
            return true;
        }
    }
    public sealed class Parrot : Bird
    {

    public Parrot(string name, double weight, ushort birthYear) : base(name, weight, birthYear, new AnimalInfo
    {
        Habitat = "Джунгли",
        ConservationStatus = "Мало охраняемый"
    })
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


    public class ZooContainer
    {
        private List<Animal> animals = new List<Animal>();

        public void AddAnimal(Animal animal)
        {
            animals.Add(animal);
        }

        public bool RemoveAnimal(Animal animal)
        {
            return animals.Remove(animal);
        }

        public List<Animal> GetAnimals()
        {
            return animals;
        }

        public void PrintAnimals()
        {
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
    public class ZooController
    {
        private ZooContainer zoo = new ZooContainer();

        public void AddAnimal(Animal animal)
        {
            zoo.AddAnimal(animal);
        }

        public double GetAverageWeightByType(AnimalType type)
        {
            var animalsOfType = zoo.GetAnimals().Where(a => a.GetType().BaseType.Name == type.ToString());
            if (!animalsOfType.Any())
            {
                return 0.0;
            }

            return animalsOfType.Average(a => a.kg_weight);
        }

        public int CountPredatoryBirds()
        {
            return zoo.GetAnimals().Count(a => a is Bird && a.IsHunt());
        }

        public void SortAnimalsByBirthYear()
        {
            var sortedAnimals = zoo.GetAnimals().OrderBy(a => a.year_of_birth);
            foreach (var animal in sortedAnimals)
            {
                Console.WriteLine(animal);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            ZooController zooController = new ZooController();

            Animal lion = new Lion("Simba", 190, 1999);
            Animal owl = new Owl("Hedwig", 0.2, 2010);
            Animal owl2 = new Owl("Hedwig", 0.2, 2010);
            Animal tiger = new Tiger("Rajah", 250, 2005);
            Animal crocodile = new Crocodile("Croc", 400, 1990);
            Animal shark = new Shark("Jaws", 1000, 1979);
            Animal parrot = new Parrot("Polly", 0.456, 2020);

            zooController.AddAnimal(lion);
            zooController.AddAnimal(owl);
            zooController.AddAnimal(owl2);
            zooController.AddAnimal(tiger);
            zooController.AddAnimal(crocodile);
            zooController.AddAnimal(shark);
            zooController.AddAnimal(parrot);

            double avgLionWeight = zooController.GetAverageWeightByType((AnimalType)1);
            int predatoryBirdCount = zooController.CountPredatoryBirds();

            Console.WriteLine($"Средний вес млекопитающих: {avgLionWeight} кг");
            Console.WriteLine($"Количество хищных птиц: {predatoryBirdCount}");

            Console.WriteLine("Животные, отсортированные по году рождения:");
            zooController.SortAnimalsByBirthYear();
           
        }
    }
}