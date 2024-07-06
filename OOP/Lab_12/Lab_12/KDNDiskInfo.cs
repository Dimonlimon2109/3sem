using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12
{
    public static class KDNDiskInfo
    {
        public static void GetDiskInfo()
        {
            foreach(var inff in DriveInfo.GetDrives())
            {
                Console.WriteLine($"Имя диска: {inff.Name}");
                Console.WriteLine($"Свободное место на диске: {inff.AvailableFreeSpace}");
                Console.WriteLine($"Файловая система: {inff.DriveFormat}");
                if (inff.IsReady)
                {
                    Console.WriteLine($"Объём диска: {inff.TotalSize}");
                    Console.WriteLine($"Свободное пространство: {inff.TotalFreeSpace}");
                    Console.WriteLine($"Метка: {inff.VolumeLabel}");
                }
            }
            KDNLog.Write("KDNDiskInfo", MethodBase.GetCurrentMethod()!.Name);
        }
    }
}
