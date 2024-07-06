using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12
{
    static class KDNFileManager
    {
        static public void GetFileAndDir(string NameDisk)
        {
            if (NameDisk is null)
            {
                throw new ArgumentNullException(nameof(NameDisk));
            }

            DirectoryInfo di = new(NameDisk);
            FileInfo[] fiArr = di.GetFiles();
            Console.WriteLine();
            Console.WriteLine($"Файлы диска {NameDisk} :");

            foreach (FileInfo fi in fiArr)
                Console.WriteLine(fi);

            Console.WriteLine($"\nПапки диска {NameDisk} :");
            DirectoryInfo[] fiArr2 = di.GetDirectories();

            foreach (DirectoryInfo fi in fiArr2)
                Console.WriteLine(fi);

            KDNLog.Write("KDNFileManager", MethodBase.GetCurrentMethod()!.Name);
        }
        static public void CreateDirAndFile(string NameDir, string NameFile)
        {
            if (NameDir is null)
            {
                throw new ArgumentNullException(nameof(NameDir));
            }

            if (NameFile is null)
            {
                throw new ArgumentNullException(nameof(NameFile));
            }

            DirectoryInfo dirInfo = new(NameDir);

            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            using (StreamWriter writer = new(NameFile, false))
            {
                writer.WriteLine("Сохранённая информация)");
            }

            KDNLog.Write("KDNFileManager", MethodBase.GetCurrentMethod()!.Name);
        }
        static public void CopyFile(string pathFrom, string pathTo)
        {
            if (pathFrom is null)
            {
                throw new ArgumentNullException(nameof(pathFrom));
            }

            if (pathTo is null)
            {
                throw new ArgumentNullException(nameof(pathTo));
            }

            FileInfo fi = new(pathTo);

            if (!fi.Exists)
                File.Copy(pathFrom, pathTo);

            KDNLog.Write("KDNFileManager", MethodBase.GetCurrentMethod()!.Name);
        }

        static public void DelFile(string path)
        {
            if (path is null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            FileInfo fi = new(path);

            if (fi.Exists)
            {
                File.Delete(path);
            }

            KDNLog.Write("KDNFileManager", MethodBase.GetCurrentMethod()!.Name);
        }
        static public void CreateDirAndCopyFile(string nameDir, string FileExtenshion, string pathFrom)
        {
            if (nameDir is null)
            {
                throw new ArgumentNullException(nameof(nameDir));
            }

            if (FileExtenshion is null)
            {
                throw new ArgumentNullException(nameof(FileExtenshion));
            }

            if (pathFrom is null)
            {
                throw new ArgumentNullException(nameof(pathFrom));
            }

            DirectoryInfo dirFrom = new(pathFrom);
            DirectoryInfo dirTo = new(nameDir);
            dirTo.Create();
            var files = dirFrom.GetFiles();

            foreach (FileInfo f in dirTo.GetFiles())
            {
                f.Delete();
            }

            foreach (var file in files)
            {

                if (FileExtenshion.Length == 0 ||
                    FileExtenshion.Contains(file.Extension))
                {
                    file.CopyTo(dirTo.FullName + "\\" + file.Name);
                }
            }

            KDNLog.Write("KDNFileManager", MethodBase.GetCurrentMethod()!.Name);

        }

        async static public void ArchiveFile(string pathF, string targetFolder)
        {
            if (pathF is null)
            {
                throw new ArgumentNullException(nameof(pathF));
            }

            if (targetFolder is null)
            {
                throw new ArgumentNullException(nameof(targetFolder));
            }

            DirectoryInfo dir = new(pathF);
            string path = $"{dir.FullName}.zip";

            if (Directory.Exists(path))
            {
                Console.WriteLine("\nАрхив уже создан!");
            }
            else
            {
                ZipFile.CreateFromDirectory(dir.FullName, path);
            }

            try
            {
                ZipFile.ExtractToDirectory(path, targetFolder);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Файлы уже разархивированы!\n");
            }


            KDNLog.Write("KDNFileManager", "Archive File");
        }


    }
}
