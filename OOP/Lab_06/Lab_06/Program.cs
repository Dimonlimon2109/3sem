using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

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
    ///
    public void AddAnimal(Animal animal)
    {
        try
        {
            if (animal.kg_weight <= 0)
            {
                throw new AnimalInitializationException("Вес животного должен быть положительным.");
            }
            zoo.AddAnimal(animal);
        }
        catch (AnimalInitializationException ex)
        {
            Console.WriteLine($"Ошибка при добавлении животного: {ex.Message}");
            throw;
        }
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
/////////////////////////////////////////////////////////////////////////////LAB6
public class AnimalException : Exception
{
    public AnimalException(string message) : base(message) { }
}
public class Out_of_Range : ArgumentOutOfRangeException
{
    public int value;
    public Out_of_Range(string paramName, int actualValue, int minValue, int maxValue) : base(paramName, actualValue, $"Значение {actualValue} вышло за пределы. Оно должно быть между {minValue} и {maxValue}.") { }

    public string About_exception()
    {
        Console.WriteLine(Message);
        Console.WriteLine(StackTrace);
        return Message;
    }
}
public class OutOfYearRange : Out_of_Range
{
    public OutOfYearRange(string paramName, int actualValue, int minValue, int maxValue)
    : base(paramName, actualValue, minValue, maxValue)
    {
    }
}

public class AnimalInitializationException : ArgumentException
{
    public AnimalInitializationException(string message) : base(message) { }
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

        /*Console.WriteLine($"Средний вес млекопитающих: {avgLionWeight} кг");
        Console.WriteLine($"Количество хищных птиц: {predatoryBirdCount}");

        Console.WriteLine("Животные, отсортированные по году рождения:");
        zooController.SortAnimalsByBirthYear();*/
        //////////////////////////////////////////////////////////////////////////
        try
        {
            Animal lion2 = new Lion("аНТОХА", -190, 1999); // Вес не может быть отрицательным
                zooController.AddAnimal(lion2); // Здесь будет сгенерировано исключение AnimalInitializationException
        }
        catch (AnimalInitializationException ex)
        {
            Console.WriteLine($"Общая ошибка животного: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Блок finally выполняется всегда.");
        }
        try
        {
            Crocodile crocObj1 = lion as Crocodile; // приведение типов не произошло и movieObj1 принял значение null 
            crocObj1.Crawl();  // и при обращении возникл exception 
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine(ex.Message + "(Null значение)");
            Console.WriteLine(ex.StackTrace);
        }
        finally
        {
            Console.WriteLine("Идем в finally");
            Console.WriteLine();
            Console.WriteLine("--------------------------------");
            try
            {

                int a = 200000;
                int b = 200000;
                int c = checked(a * b);

            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.HelpLink);
                Console.WriteLine(ex.Message);
                Console.WriteLine(DateTime.Now);
                Console.WriteLine(ex.StackTrace);
            }

            finally { Console.WriteLine("Вложенность продемонстрирована"); }
        }
        try
        {
            Animal parrot2 = new Parrot("Петя", 0.5, 1900);
            if (parrot2.year_of_birth < 1935) throw new OutOfYearRange("Год рождения", parrot2.year_of_birth, minValue: 1935, maxValue: 2023);
        }
        catch (OutOfYearRange ex)
        {
            ex.About_exception();


        }
        Animal[] animals2 = { lion, crocodile, parrot };
        Printer printer = new Printer();
        Console.WriteLine();
        Console.WriteLine("--------------------------------");
        try
        {
            printer.IAmPrinting(animals2[3]);
        }

        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine(ex.Message);
            Console.WriteLine(DateTime.Now);
            Console.WriteLine(ex.HelpLink);

        }
        Console.WriteLine();
        Console.WriteLine("--------------------------------");
        try
        {
            // Исключение пользовательское
            throw new AnimalException("Это пользовательское исключение.");
        }
        catch (AnimalException ex)
        {
            Console.WriteLine("Пользовательское исключение:");
            Console.WriteLine($"Исключение: {ex.GetType().Name}");
            Console.WriteLine($"Сообщение: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Универсальный обработчик catch:");
            Console.WriteLine($"Исключение: {ex.GetType().Name}");
            Console.WriteLine($"Сообщение: {ex.Message}");
        }
        finally
        {
            Console.WriteLine();
            Console.WriteLine("--------------------------------");
        }
        int[] aa = null;
        Debug.Assert(aa != null, "Values array cannot be null");
        Debug.WriteLine("asdasdasd");
        int x = 10;
        Debug.Assert(x == 10, "x должно быть равно 10.");
    }
}