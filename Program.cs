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
        }
    }
}
