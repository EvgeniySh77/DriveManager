using System;
using System.IO;

namespace DriveManager
{
    class Program
    {
        static void Main()
        {
            // получим системные диски
            DriveInfo[] drives = DriveInfo.GetDrives();

            // Пробежимся по дискам и выведем их свойства
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Название: {drive.Name}");
                Console.WriteLine($"Тип: {drive.DriveType}");
                if (drive.IsReady)
                {
                    Console.WriteLine($"Объем: {drive.TotalSize / 1000_000_000} Гб");
                    Console.WriteLine($"Свободно: {drive.TotalFreeSpace / 1000_000_000} Гб");
                    Console.WriteLine($"Метка: {drive.VolumeLabel}");
                }
            }

            Console.ReadKey();
            Console.WriteLine(Environment.NewLine);

            GetCatalogs(); //   Вызов метода получения директорий

            Console.ReadKey();
            Console.WriteLine(Environment.NewLine);

            CountNumOfFoldersAndFiles(); //   Вызов метода подчета количества папок и файлов

            Console.ReadKey();

            //CreateCatalog(); //   Создаем каталог

            //Console.ReadKey();
        }

        static void CountNumOfFoldersAndFiles()
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(@"E:\\");
                if (dirInfo.Exists)
                {
                    Console.WriteLine(dirInfo.GetDirectories().Length + dirInfo.GetFiles().Length);
                }
                DirectoryInfo newDirectory = new DirectoryInfo(@"E:\Личная папка");
                if (!newDirectory.Exists)
                    newDirectory.Create();

                newDirectory.CreateSubdirectory("Просто папка");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void GetCatalogs()
        {
            string dirName = @"E:\"; // Прописываем путь к корневой директории MacOS (для Windows скорее всего тут будет "C:\\")
            if (Directory.Exists(dirName)) // Проверим, что директория существует
            {
                Console.WriteLine("Папки:");
                string[] dirs = Directory.GetDirectories(dirName);  // Получим все директории корневого каталога

                foreach (string d in dirs) // Выведем их все
                    Console.WriteLine(d);

                Console.WriteLine();
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(dirName);// Получим все файлы корневого каталога

                foreach (string s in files)   // Выведем их все
                    Console.WriteLine(s);
            }
        }

        //static void CreateCatalog()        
        //{
        //    DirectoryInfo dirInfo = new DirectoryInfo(@"E:");
        //    if (!dirInfo.Exists)
        //        dirInfo.Create();

        //    //dirInfo.CreateSubdirectory("NewFolder");
        //}
    }
}
