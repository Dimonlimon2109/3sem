using System;
using System.Collections.Generic;

// Класс, представляющий язык программирования
namespace Lab_08
{

    class Program
    {
        static void Main()
        {
            Programmer prog1 = new Programmer("Дмитрий");

            ProgrammingLanguage lang1 = new ProgrammingLanguage("C#", 7.0, "Add", "Del", "Rename") ;
            ProgrammingLanguage lang2 = new ProgrammingLanguage("C++", 12.1, "Add", "Del");
            prog1.Rename += lang1.Rename_L;
            prog1.Rename += lang2.Rename_L;
            prog1.NewProperty += lang1.Add;
            prog1.NewProperty += lang2.Add;
            prog1.NewProperty += lang1.Add;
            prog1.NewProperty += lang2.Add;
            prog1.NewProperty += lang1.Delete;
            prog1.NewProperty += lang2.Delete;

            prog1.CommandRenameOperation();
            prog1.CommandAddOperation();

            Console.WriteLine(lang1);
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine(lang2);
            Console.WriteLine("--------------------------------------------------");


            Console.WriteLine("Работа со строками с помощью стандартных типов делегатов:");
            Func<string, string> test1;  //обобщенный делегат, второй параметр - возврат 
            Action<string> test2;       //не возвр значений
            Func<string, string> test3;
            Func<string, string> test4;
            Func<string, string> test5;
            test1 = str1 =>
            {
                char[] sign = { '.', ',', '!', '?', '-', ':' };
                for (int i = 0; i < str1.Length; i++)
                {
                    if (sign.Contains(str1[i]))
                    {
                        str1 = str1.Remove(i, 1);
                    }
                }
                Console.WriteLine("Удаление знаков препинания: ");
                Console.WriteLine(str1);
                return str1;
            };
            test2 = delegate (string str2)   //анонимный метод
            {
                str2 += Console.ReadLine();
                Console.WriteLine("Добавление новой строки: ");
                Console.WriteLine(str2);
            };
            test3 = str3 =>
            {
                str3 = str3.Replace(" ", string.Empty);
                Console.WriteLine("Удаление пробелов: ");
                Console.WriteLine(str3);
                return str3;
            };
            test4 = str4 =>
            {
                str4 = str4.ToUpper();
                Console.WriteLine("Перевод текста в верхний регистр: ");
                Console.WriteLine(str4);
                return str4;
            };
            string str = "My name is Anton, what is your name?";
            Console.WriteLine("Строка в начале: " + str);
            string s1, s2, s3;
            s1 = StringWork.RemoveS(str, test1);
            StringWork.AddToString(s1, test2);
            s2 = StringWork.RemoveSpaces(s1, test3);
            s3 = StringWork.Upper(s2, test4);
        }
    }
}