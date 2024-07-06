using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

class Stack
{
    private readonly int ID; //переменная только для чтения
    public const double PI = Math.PI;
    public int id
    {
        get { return ID; }
    }
    public List<double> stack { get; } = new List<double>();

    public static int NumberOfStacksCreated { get; private set; } = 0;
    static Stack()
    {
        // Статический конструктор
        NumberOfStacksCreated = 0;
        Console.WriteLine("Статический конструктор вызван");
    }
    public double this[int index]
    {
        get
        {
            if (index >= 0 && index < stack.Count)
                return stack[index];
            else
                throw new IndexOutOfRangeException("Индекс находится за пределами диапазона");
        }
    }
    public bool IsEmpty
    {
        get { return stack.Count == 0; }
    }

    public int Count
    {
        get { return stack.Count; }
    }
    public void Push(double value) //добавление элемента в стек
    {
        stack.Add(value);
    }

    public double Pop() //удаление элемента из стека
    {
        if (stack.Count == 0)
            throw new InvalidOperationException("Стек пуст.");
        double item = stack[stack.Count - 1];
        stack.RemoveAt(stack.Count - 1);
        return item;
    }
    public Stack() //конструктор без параметров
    {
        this.Push(1.4);
        this.Push(-2.8);
        this.Push(4.2);
        NumberOfStacksCreated++;
    }
    public Stack(params double[] numbers) //конструктор с переменным числом параметров
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            this.Push(numbers[i]);
        }
        NumberOfStacksCreated++;
    }
    public Stack(double a, double b = 3.5, double c = 0.4, double d = 1.1) 
        //конструктор с параметрами по умолчанию
    {
        this.Push(a);
        this.Push(b);
        this.Push(c);
        this.Push(d);
        NumberOfStacksCreated++;
    }
    public void IncreaseStackValues(ref double incrementValue, out int modifiedCount)
    {
        modifiedCount = 0; // Инициализируем out-параметр

        for (int i = 0; i < stack.Count; i++)
        {
            stack[i] += incrementValue;
            modifiedCount++;
        }
    }
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        Stack other = (Stack)obj;
        return stack.Equals(other.stack);
    }

    public override int GetHashCode()
    {
        return stack.GetHashCode();
    }

    public override string ToString()
    {
        return string.Join(", ", stack);
    }

    /*    private Stack() { }*/ //закрытый конструктор
    public static void PrintClassInfo()
    {
        Console.WriteLine($"Количество созданных стеков: {NumberOfStacksCreated}");
    }
}

partial class Program
{
    static void Main(string[] args)
    {
        Stack[] stacks = new Stack[3];

        // Создание объектов с помощью разных конструкторов
        stacks[0] = new Stack();
        stacks[1] = new Stack(1.5, -1.1, 23.452, 0.333, 30.1);
        stacks[2] = new Stack(1.111);
        // Добавление и удаление элементов
        stacks[0].Push(10);
        stacks[0].Push(20);
        stacks[0].Push(30);
        stacks[0].Pop();
        double incrementValue = 0.5;
        int modifiedCount;
        stacks[1].IncreaseStackValues(ref incrementValue, out modifiedCount);
        // Вывод информации о стеках
        Stack.PrintClassInfo();
        Stack stackWithMinTopElement = stacks.OrderBy(s => s[s.Count - 2]).First();
        Stack stackWithMaxTopElement = stacks.OrderByDescending(s => s[s.Count - 2]).First();

        Console.WriteLine("Стек с наименьшим верхним элементом:");
        for (int i = 0; i < stackWithMinTopElement.Count; i++)
        {
            Console.WriteLine(stackWithMinTopElement[i]);
        }

        Console.WriteLine("Стек с наибольшим верхним элементом:");
        for (int i = 0; i < stackWithMaxTopElement.Count; i++)
        {
            Console.WriteLine(stackWithMaxTopElement[i]);
        }
        // b) Находим список стеков, содержащих отрицательные элементы
        List<Stack> stacksWithNegativeElements = stacks.Where(s => s.stack.Any(e => e < 0)).ToList();

        Console.WriteLine("Список стеков, содержащих отрицательные элементы:");
        foreach (var stack in stacksWithNegativeElements)
        {
            for (int i = 0; i < stack.Count; i++)
            {
                Console.Write(stack[i] + ", " );
            }
            Console.Write('\n');
        }
    }
}

