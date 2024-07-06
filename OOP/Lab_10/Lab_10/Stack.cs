using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10
{
    public class Stack
    {
        public List<double> stack { get; } = new List<double>();
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
        public Stack(params double[] numbers) //конструктор с переменным числом параметров
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                this.Push(numbers[i]);
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
    }
}
