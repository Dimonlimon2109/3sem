using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_08
{
public static class StringWork
    {
        public static string RemoveS(string str, Func<string, string> test1) //удаление знаков
        {

            return test1(str);
        }
        public static void AddToString(string str, Action<string> test2) => test2(str);  //добавление строки
        public static string RemoveSpaces(string str, Func<string, string> test3) //удаление пробелов
        {
            return test3(str);
        }
        public static string Upper(string str, Func<string, string> test4)  //в верхний регистр
        {
            return test4(str);
        }
    }
}
