using System;

namespace Lab_11
{
    class Program
    {
        static void Main()
        {
            Reflector<Shark>.GetNameAssembly();
            Reflector<Shark>.publicConstructor();
            Reflector<Shark>.allPublicMethods();
            Reflector<Shark>.getInformationAboutFields();
            Reflector<Shark>.getInterface();
            Reflector<Shark>.GetMethodsByParamType();
            Reflector<Shark>.Invoke("Method.txt");
            Shark shark = Reflector<Shark>.Creator<Shark>();
            Console.WriteLine("Создан экземпляр класса shark : " + shark);
        }
    }

}