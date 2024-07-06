using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Lab_13
{
    class Program
    {
        static void Main()
        {
            Tiger tiger1 = new Tiger("Артём", 100, 1990, 80);
            Tiger tiger2 = new Tiger("Ваня", 96, 2000, 90);
            Tiger tiger3 = new Tiger("Гена", 105, 1999, 110);
            Tiger tiger4 = new Tiger("Стас", 99, 2009, 91);
            List<Tiger> tigers = new List<Tiger>();
            tigers.Add(tiger1);
            tigers.Add(tiger2);
            tigers.Add(tiger3);
            tigers.Add(tiger4);

            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream("tiger.dat", FileMode.OpenOrCreate))
            {
               bf.Serialize(fs, tiger1);
                Console.WriteLine("tiger1 сериализован!");
            }
            
            using (FileStream fs = new FileStream("tiger.dat", FileMode.OpenOrCreate))
            {
                Tiger tiger_bin = (Tiger)bf.Deserialize(fs);
                Console.WriteLine($"Результат десериализации: {tiger_bin.ToString()}");
            }

            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Tiger));
            using (FileStream fs = new FileStream("tiger.json", FileMode.OpenOrCreate))
            {
                jsonSerializer.WriteObject(fs, tiger3);
                Console.WriteLine("tiger3 сериализован в json!");
            }

            using (FileStream fs = new FileStream("tiger.json", FileMode.OpenOrCreate))
            {
              Tiger tiger_json = (Tiger)jsonSerializer.ReadObject(fs);
                Console.WriteLine($"Результат десериализации: {tiger_json.ToString()}");
            }

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Tiger));
            using (FileStream fs = new FileStream("tiger.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, tiger4);
                Console.WriteLine("tiger4 сериализован в xml!");
            }
            using (FileStream fs = new FileStream("tiger.xml", FileMode.OpenOrCreate))
            {
                Tiger tiger_xml = (Tiger)xmlSerializer.Deserialize(fs);
                Console.WriteLine($"Результат десериализации: {tiger_xml.ToString()}");
            }  
            XmlSerializer serializer = new XmlSerializer(typeof(List<Tiger>));
            using (FileStream fs = new FileStream("task2.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, tigers);
                Console.WriteLine("tigers сериализирован!");
            }
            using (FileStream fs = new FileStream("task2.xml", FileMode.OpenOrCreate))
            {
                List<Tiger> tigers_ = (List<Tiger>)serializer.Deserialize(fs);
                foreach(var item in tigers_)
                {
                    Console.WriteLine($"Десериализован: {item.ToString()}");
                }
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("tiger.xml");
            XmlElement xRoot = xmlDoc.DocumentElement;

            XmlNodeList nodes = xRoot.SelectNodes("*");
            foreach (XmlNode node in nodes)
                Console.WriteLine(node.OuterXml);
            nodes = xRoot.SelectNodes("Name");
            foreach (XmlNode node in nodes)
                Console.WriteLine(node.OuterXml);
            XDocument xDocument = new XDocument();
            XElement game1 = new XElement("Dota2", new XAttribute("company", "Valve"), new XElement ("year", "2011"), new XElement("genre", "MOBA"));
            XElement game2 = new XElement("Valorant", new XAttribute("company", "Riot Games"), new XElement("year", "2009"), new XElement("genre", "MOBA"));
            XElement root = new XElement("Games", new XElement(game1), new XElement(game2));
            xDocument.Add(root);
            xDocument.Save("games.xml");
        }
    }
}