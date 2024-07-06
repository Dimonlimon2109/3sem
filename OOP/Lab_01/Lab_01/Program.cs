using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;


class MainClass
{
    static void Main()
    {/////////////////TASK 1
        bool a = true;
        Console.WriteLine("Введите bool");
        a = Convert.ToBoolean(Console.ReadLine());
        Console.WriteLine(a);
        byte b = 8;
        Console.WriteLine("Введите byte");
        b = Convert.ToByte(Console.ReadLine());
        Console.WriteLine(b);
        sbyte s = -20;
        Console.WriteLine("Введите sbyte");
        s = Convert.ToSByte(Console.ReadLine());
        Console.WriteLine(s);
        char c = 'c';
        Console.WriteLine("Введите char");
        c = Convert.ToChar(Console.ReadLine());
        Console.WriteLine(c);
        decimal d = 2.5m;
        Console.WriteLine("Введите decimal");
        d = Convert.ToDecimal(Console.ReadLine());
        Console.WriteLine(d);
        double doub = 3.22;
        Console.WriteLine("Введите double");
        doub = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine(doub);
        float f = 5.4f;
        Console.WriteLine("Введите float");
        f = Convert.ToSingle(Console.ReadLine());
        Console.WriteLine(f);
        int i = 69;
        Console.WriteLine("Введите int");
        i = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(i);
        uint u = 99;
        Console.WriteLine("Введите uint");
        u = Convert.ToUInt32(Console.ReadLine());
        Console.WriteLine(u);
        nint n = 100;
        Console.WriteLine("Введите nint");
        n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(n);
        nuint nu = 999;
        Console.WriteLine("Введите nuint");
        nu = Convert.ToUInt32(Console.ReadLine());
        Console.WriteLine(nu);
        long l = -228;
        Console.WriteLine("Введите long");
        l = Convert.ToInt64(Console.ReadLine());
        Console.WriteLine(l);
        ulong ul = 321;
        Console.WriteLine("Введите ulong");
        ul = Convert.ToUInt64(Console.ReadLine());
        Console.WriteLine(ul);
        short sh = 567;
        Console.WriteLine("Введите short");
        sh = Convert.ToInt16(Console.ReadLine());
        Console.WriteLine(sh);
        ushort ush = 633;
        Console.WriteLine("Введите ushort");
        ush = Convert.ToUInt16(Console.ReadLine());
        Console.WriteLine(ush);
        i = (int)l;
        i = (int)ul;
        i = (int)sh;
        i = (int)ush;
        s = (sbyte)b;
        l = i + 10;
        ul = ush;
        sh = b;
        i = sh;
        doub = f;

        int q = 5;
        object obj = q;
        q = (int)obj;
        var ima = "hhh";
        int? nl = null;
        //ima = 7;
        ////////////////////TASK 2
        string str1 = "Hello my name is";
        string str2 = "Goodbye";
        Console.WriteLine(str1 == str2);
        Console.WriteLine(string.Concat(str1 + ' ' + str2 + " - сцепление"));
        Console.WriteLine(string.Copy(str2) + "- копирование");
        Console.WriteLine(str1.Substring(0, 3) + " - выделение подстроки");
        string[] words = str1.Split(new char[] { ' ' });
        Console.WriteLine("Разделение строки на слова: ");
        foreach (string word in words)
        {
            Console.WriteLine(word);
        }
        str1 = str1.Insert(6, str2);
        Console.WriteLine(str1 + " - вставка подстроки в заданную позицию");
        str2 = str2.Remove(str2.Length - 3, 3);
        Console.WriteLine(str2 + " - удаление заданной подстроки");
        Console.WriteLine($"Интерполирование строк: Say {str2} , not {str1}");
        string none = "";
        string? not = null;
        Console.WriteLine("использование string.IsNullOrEmpty: ");
        Console.WriteLine(string.IsNullOrEmpty(none));
        Console.WriteLine(string.IsNullOrEmpty(not));
        Console.WriteLine("StringBuilder: ");
        StringBuilder name = new StringBuilder("Yqwmitr");
        name.Remove(0, 3);
        Console.WriteLine(name);
        name.Insert(0, 'D');
        name.Append('y');
        Console.WriteLine(name);
        //////////task 3
        Console.WriteLine("Двумерный массив: ");
        int[,] numbers = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        int rows = numbers.GetUpperBound(0) + 1;    // количество строк
        int columns = numbers.Length / rows;        // количество столбцов

        for (int cnt = 0; cnt < rows; cnt++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write($"{numbers[cnt, j]}" + "  ");
            }
            Console.WriteLine();
        }
        string[] dota = { "Defense", "of", "the", "Ancients" };
        int number_of_letters = 0;
        for (int j = 0; j < dota.Length; j++)
        {
            number_of_letters += dota[j].Length; 
            Console.WriteLine(dota[j]);
        }
        int variant = 0;
        Console.WriteLine("Длина массива " + number_of_letters);
        while (variant > 4 || variant < 1)
        {
            Console.WriteLine("Введите номер слова для изменения: ");
            variant = Convert.ToInt32(Console.ReadLine());
        }
        Console.WriteLine("Введите слово: ");
        string wor = Console.ReadLine();
        dota[variant - 1] = wor;
        Console.WriteLine("Массив после изменения: ");
        for (int j = 0; j < dota.Length; j++)
        {
            Console.WriteLine(dota[j]);
        }
        Console.WriteLine("\n" + "Ступенчатый массив с вещественными числами");
        double[][] myArr = new double[3][] { new double[2], new double[3], new double[4] };
        for (int cnt2 = 0; cnt2 < myArr.Length; cnt2++)
        {
            for (int j = 0; j < myArr[cnt2].Length; j++)
            {
                Console.Write($"myArr[{cnt2}][{j}] = ");
                myArr[cnt2][j] = Convert.ToDouble(Console.ReadLine());
            }
        }
        Console.WriteLine("\n");
        for (int cnt2 = 0; cnt2 < myArr.Length; cnt2++)
        {
            Console.WriteLine(string.Join(" ", myArr[cnt2]));
        }
        var no_type = "Thanks";
        var massiv = new[] { 1, 2, 3, 4, };
        Console.WriteLine(no_type + " - строка ");
        Console.WriteLine("Строка:");
        for (int cnt2 = 0; cnt2 < massiv.Length; cnt2++)
        {
            Console.WriteLine(string.Join(" ", massiv[cnt2]));
        }
        /////task4
        (int, string, char, string, ulong) tuple = (6, "mark", 'D', "POIT", 228);
        Console.WriteLine("1, 3, 4 элементы кортежа: ");
        Console.WriteLine(tuple.Item1);
        Console.WriteLine(tuple.Item3);
        Console.WriteLine(tuple.Item4);
        Console.WriteLine("Распаковка кортежа: ");
        var (a_1, b_1, c_1, d_1, e_1) = tuple;
        Console.WriteLine(a_1);
        Console.WriteLine(b_1);
        Console.WriteLine(c_1);
        Console.WriteLine(d_1);
        Console.WriteLine(e_1);
        Console.WriteLine("\n" + "Использование переменной(_)");
        var (f_1, _, _, j_1, _) = tuple;
        Console.WriteLine(f_1);
        Console.WriteLine(j_1);
        (int, string, char, string, ulong) tuple1 = (5, "mark", 'D', "POIT", 228);
        Console.WriteLine(tuple == tuple1);
        //////task 5
        (int, int, int, char) LocalFunction(int[] nums, string strr)
        {
            int maxEl = 0;
            int minEl = Int32.MaxValue;
            int sum = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                sum += nums[j];
                if (nums[j] > maxEl)
                    maxEl = nums[j];
                if (nums[j] < minEl)
                    minEl = nums[j];
            }
            char firstSymbol = strr[0];
            var tuplee = (maxEl, minEl, sum, firstSymbol);
            return tuplee;
        }
        string strr = "Dmitry";
        int[] ints = { 10, 1, 190, 300 };
        Console.WriteLine(LocalFunction(ints, strr));
        ///task6
        void Checked()
        {
            checked
            {
                int Max = int.MaxValue;
                Console.WriteLine(Max);
            }
        }
        void Unchecked()
        {
            unchecked
            {
                int Max = int.MaxValue + 1;
                Console.WriteLine(Max);
            }
        }
        Checked();
        Unchecked();
    }
}