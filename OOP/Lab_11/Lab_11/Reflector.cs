using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_11
{
    public static class Reflector<T> where T : class, new()
    {
        private static Type type = typeof(T);
        private static string nameFile = "ClassInfo.txt";
        public static string GetNameAssembly()
        {
            Console.WriteLine($"Информация про сборку:   {type.Assembly.FullName}.");
            using (StreamWriter writer = new(nameFile, false))
            {
                writer.WriteLine("Сборка:" + type.Assembly.FullName);
            }

            return "";
        }

        public static void publicConstructor()
        {
            if (type.GetConstructors().Any(constructor => constructor.IsPublic))
            {
                Console.WriteLine("\nПубличный конструктор присутствует!\n");

                using (StreamWriter writer = new(nameFile, true))
                {
                    writer.WriteLine("\nПубличный конструктор присутствует!\n");
                }
            }
            else
            {
                Console.WriteLine("\nПубличный конструктор отсутсвует!\n");

                using (StreamWriter writer = new(nameFile, true))
                {
                    writer.WriteLine("\nПубличный конструктор отсутствует!\n");
                }
            }
        }

        public static void allPublicMethods()
        {
            Console.WriteLine("\nПубличные методы:");
            int count = 0;

            foreach (MethodInfo method in type.GetMethods())
            {
                Console.WriteLine($"Название метода: {method.Name}");
                using (StreamWriter writer = new(nameFile, true))
                {
                    writer.WriteLine($"Название метода: {method.Name}");
                }

                count++;
            }
            if (count == 0)
            {
                Console.WriteLine("Public-методы отсутствуют");
                using (StreamWriter writer = new(nameFile, true))
                {
                    writer.WriteLine("\nPublic-методы отсутствуют");
                }
            }
        }

        public static void getInformationAboutFields()
        {
            Console.WriteLine("\nИнформация про поля и свойства:");
            using (StreamWriter writer = new(nameFile, true))
            {
                writer.WriteLine("\nИнформация про поля и свойства:");
            }
            int count = 0;

            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
            int i = 0;
            string nameType;

            foreach (var field in fields)
            {
                i++;
                nameType = field.FieldType.ToString(); // получить название типа поля field структуры Worker
                Console.Write($"\nПоле(свойство)[{i}] = {field.Name}, тип = {nameType}, модификатор доступа: ");
                using (StreamWriter writer = new(nameFile, true))
                {
                    writer.Write($"Поле(свойство)[{i}] = {field.Name}, тип = {nameType}, модификатор доступа: ");
                }

                if (field.IsStatic)
                {
                    Console.Write("static");
                    using (StreamWriter writer = new(nameFile, true))
                    {
                        writer.Write("static\n");
                    }
                }

                if (field.IsPublic)
                {
                    Console.Write("public");
                    using (StreamWriter writer = new(nameFile, true))
                    {
                        writer.Write("public\n");
                    }
                }

                if (field.IsPrivate)
                {
                    Console.Write("private");
                    using (StreamWriter writer = new(nameFile, true))
                    {
                        writer.Write("private\n");
                    }
                }
                Console.WriteLine();
                count++;
            }

            if (count == 0)
            {
                Console.WriteLine("Полей или свойств нету!");
                using (StreamWriter writer = new(nameFile, true))
                {
                    writer.WriteLine("\nПолей или свойств нету!");
                }
            }
        }

        public static void getInterface()
        {
            int i = 0;
            foreach (Type t in type.GetInterfaces())
            {
                i++;
                Console.WriteLine("\nИнтерфейс[{0}] = {1}", i, t.Name);
                using (StreamWriter writer = new(nameFile, true))
                {
                    writer.WriteLine("\nИнтерфейс[{0}] = {1}", i, t.Name);
                }

            }

            if (i == 0)
            {
                Console.WriteLine("\nКласс не наследуется от интерфейсов!");
                using (StreamWriter writer = new(nameFile, true))
                {
                    writer.WriteLine("\n\nКласс не наследуется от интерфейсов!");
                }
            }
        }

        public static void GetMethodsByParamType()
        {
            Console.WriteLine("Введите тип параметра: ");
            string param = Console.ReadLine();
            foreach(var i in type.GetMethods())
            {
                foreach (var j in i.GetParameters())
                {
                    if (j.ParameterType.Name == param)
                    {
                        Console.WriteLine("Параметр типа " +  param + " есть в методе " + i.Name + "\n");
                        using (StreamWriter writer = new(nameFile, true))
                        {
                            writer.WriteLine("Параметр типа " + param + " есть в методе " + i.Name + "\n");
                        }
                        break;
                    }
                }
            }
        }
        public static void Invoke(string fileWithInformation)
        {
            string info = File.ReadAllText(fileWithInformation);
            Console.WriteLine('\n');

            info.Split(new char[] { ' ' });

            string name = String.Empty,
                   par = String.Empty;

            int countOfPar = 0;

            for (int i = 0; i < info.Length; i++)
            {
                if (info[i] == '&')
                    countOfPar++;
            }

            countOfPar += 1;
            string[] allPar = new string[countOfPar];

            for (int i = 0; i < info.Length; i++)
            {

                if (info[i] == '(')
                {
                    for (int j = i + 1; j < info.Length - 1; j++)
                    {
                        par += info[j];
                    }
                    break;
                }
                else
                    name += info[i];
            }


            Console.WriteLine("-----------------");
            Console.WriteLine($"Будет вызвана функция {name}, и переданы параметры: {par}");

            string[] parametr = par.Split('&');

            int p1 = Convert.ToInt32(parametr[0]);
            double p2 = Convert.ToDouble(parametr[1]);

            MethodInfo methodInfo = type.GetMethod(name);

            if (methodInfo != null)
            {
                object result = null;
                ParameterInfo[] parameters = methodInfo.GetParameters();
                object classInstance = Activator.CreateInstance(type, null);

                if (parameters.Length == 0)
                {
                    result = methodInfo.Invoke(classInstance, null);
                }

                else
                {
                    object[] parametersArray = new object[] { p1, p2 };
                    result = methodInfo.Invoke(classInstance, parametersArray);
                }
            }


        }
        public static T Creator<T>() where T : class, new()
        {
            return new T();
        }
        public static T Create<T>()
        {
            Type objectType = typeof(T);

            // Получаем все публичные конструкторы для заданного типа
            ConstructorInfo[] constructors = objectType.GetConstructors();

            // Ищем конструктор без параметров
            ConstructorInfo defaultConstructor = Array.Find(constructors, constructor => constructor.GetParameters().Length == 0);

            if (defaultConstructor != null)
            {
                // Если есть конструктор без параметров, создаем объект с его помощью
                return (T)defaultConstructor.Invoke(new object[] { });
            }
            else
            {
                // Если конструктора без параметров нет, выбрасываем исключение или возвращаем null, в зависимости от требований
                throw new InvalidOperationException("Тип " + objectType.Name + " не имеет конструктора без параметров.");
                // Или вернуть default(T) или null, если это необходимо
            }
        }
    }
}
