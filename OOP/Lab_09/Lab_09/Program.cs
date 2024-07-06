using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Numerics;

namespace Lab_09
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDictionary<int, Conserts> dictionary = new MyDictionary<int, Conserts>();
            Conserts consert1 = new Conserts("Макс Корж", 100);
            Conserts consert2 = new Conserts("Eminem", 50);
            Conserts consert3 = new Conserts("Lil Peep", 200);
            Conserts consert4 = new Conserts("Lil Tracy", 1000);
            dictionary.Add(MyDictionary<int, Conserts>.id++, consert1);
            dictionary.Add(MyDictionary<int, Conserts>.id++, consert2);
            dictionary.Add(MyDictionary<int, Conserts>.id++, consert3);
            dictionary.Print();
            dictionary.Remove(1);
            dictionary.Add(MyDictionary<int, Conserts>.id++, consert4);
            dictionary.Print();
            Conserts value;
            dictionary.TryGetValue(0, out value);
            Console.WriteLine(value.ToString());

            int dictionary1_id = 0;
            MyDictionary<int, char> dictionary1 = new MyDictionary<int, char>();
            for(; dictionary1_id< 6; dictionary1_id++)
            {
                dictionary1.Add(dictionary1_id, (char)dictionary1_id);
            }
            dictionary1.Print();
            for(int i = 0; i < 3; i++)
                dictionary1.Remove(i);
            Console.WriteLine("----------------------------------------------------");
            dictionary1_id += 100;
            dictionary1.Add(dictionary1_id, (char)dictionary1_id++);
            dictionary1.Add(dictionary1_id, (char)dictionary1_id++);
            dictionary1.Add(dictionary1_id, (char)dictionary1_id++);
            dictionary1.Add(dictionary1_id, (char)dictionary1_id++);
            dictionary1.Print();
            int id = 0;
            SortedList<int,Conserts> list = new SortedList<int,Conserts>();
            list.Add(id++, consert1);
            list.Add(id++, consert2); 
            list.Add(id++, consert3);
            foreach(var item in list)
            {
                Console.WriteLine(item);
            }
            list.TryGetValue(2, out value);
            Console.WriteLine("Найденное значение с ключом 2: " +  value);
            Console.WriteLine("-------------------------------------");
            var obs_collect_conserts = new ObservableCollection<Conserts>();
            Conserts morgen = new Conserts("Моргенштерн", 2000);

            obs_collect_conserts.CollectionChanged += obs_collect_conserts_CollectionChanged;
            obs_collect_conserts.Add(morgen);
            obs_collect_conserts.Remove(morgen);
        }
        private static void obs_collect_conserts_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Console.WriteLine($"Добавлен новый объект");
                    break;

                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine($"Удален объект");
                    break;
            }
        }
    }
}