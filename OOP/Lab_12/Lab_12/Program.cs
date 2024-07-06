using System;

namespace Lab_12
{
    class Program
    {
        static void Main()
        {
            KDNLog.Write("Main", "begin");
            KDNDiskInfo.GetDiskInfo();
            KDNDirInfo.GetDirInfo("D:\\study\\3_sem\\OOP\\Lab_12\\Lab_12\\bin\\Debug\\net6.0");
            KDNFileInfo.GetFileInfo("D:\\study\\3_sem\\OOP\\Lab_12\\Lab_12\\bin\\Debug\\net6.0\\kdnlogfile.txt");
            KDNFileManager.GetFileAndDir("D:\\");
            KDNFileManager.CreateDirAndFile("D:\\KDNInspect", "D:\\KDNInspect\\kdndirinfo.txt");
            KDNFileManager.CopyFile("D:\\KDNInspect\\kdndirinfo.txt", "D:\\KDNInspect\\kdndirinfoCOPY.txt");
            //KDNFileManager.DelFile("D:\\KDNInspect\\kdndirinfo.txt");
            KDNFileManager.CreateDirAndCopyFile("D:\\KDNFlies", ".txt", "D:\\study\\3_sem\\KPO\\SE_Lab17\\Debug\\");
            KDNFileManager.ArchiveFile("D:\\KDNFlies", "D:\\KDNInspect");
            KDNLog.Write("Main\n\n", "end");
            Console.WriteLine("Информация из файла:\n");
            KDNLog.ReadAndFind("07.11.2023", "00:00:00", "01:00:00");
            //KDNLog.DeleteInfPerHour();
        }
    }
}
