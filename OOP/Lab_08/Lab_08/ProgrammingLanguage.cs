using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_08
{
    class ProgrammingLanguage
    {
        public string nameLang { get; set; }
        public double versionLang { get; set; }
        public string[] optionsArr { get; set; }

        public ProgrammingLanguage(string nameLang, double versionLang, params string[] optionsArr)
        {
            this.nameLang = nameLang;
            this.versionLang = versionLang;
            this.optionsArr = optionsArr;
        }
        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < this.optionsArr.Length; i++)
            {
                s = s + " " + this.optionsArr[i];
            }
            return $"Язык: {this.nameLang} версии {this.versionLang}\n Операции:{s}";
        }
        public void Add(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine($"Введите новое свойство для языка {nameLang}");
            string operation = Console.ReadLine();
            string[] temp = new string[this.optionsArr.Length + 1];
            for (int i = 0; i < this.optionsArr.Length; i++)
            {
                temp[i] = this.optionsArr[i];
            }
            temp[temp.Length - 1] = operation;
            this.optionsArr = temp;
            Console.WriteLine($"Мы добавили в язык {nameLang} операцию: {operation}");
            Console.ResetColor();
        }
        public void Delete(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine($"Введите свойство, которое необходимо удалить из языка {nameLang}:");
            string operation = Console.ReadLine();
            for (int o = 0; o < optionsArr.Length; o++)
            {
                if (optionsArr[o] == operation)
                    optionsArr[o] = "";
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Мы исключили из языка {nameLang} операцию: {operation}");
            Console.ResetColor();
        }
        public void NewVersion(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine($"Введите новую версию языка программирования {nameLang}");
            versionLang = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Мы используем новую версию нашего языка: {nameLang} {versionLang}");
            Console.ResetColor();
        }
        public void Rename_L(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine($"Введите новое название для языка {nameLang}");
            this.nameLang = Console.ReadLine();
            Console.WriteLine($"Мы переименовали язык: {nameLang}");
            Console.ResetColor();
        }
    }
}
