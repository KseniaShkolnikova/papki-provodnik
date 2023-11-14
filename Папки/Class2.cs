using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Папки
{
    internal class Class2
    {
        public static void Ocnov()
        {
            string drivee = "";
            DriveInfo[] drives = DriveInfo.GetDrives();
            Console.WriteLine("------Выберите диск--------");
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine("  " + drive.Name + "  Доступно " + drive.TotalFreeSpace / 1073741824 + " гг из " + drive.TotalSize / 1073741824);
                drivee = Convert.ToString(drive);
            }
            Console.WriteLine("  выход\n----------------------");
            int position =Class1.strelka(1, 1, drives.Length+1);   
            if (position == drives.Length+1)
            {
                Console.Clear();
                Console.WriteLine(" Пока");
                Environment.Exit(0);
            }
            else
            {
                ShowPapka(drivee);
            }          
        }
        private static void ShowPapka(string p)
        {
            while (true)
            {
                try
                {
                    if (p.Contains(".") == true)
                    {
                        Console.Clear();
                        try
                        {
                            Process.Start(new ProcessStartInfo { FileName = p, UseShellExecute = true });
                            Console.WriteLine("\n------Запускаем-------");
                            Environment.Exit(0);
                        }
                        catch (System.ComponentModel.Win32Exception)
                        {
                            Console.WriteLine("Указанному файлу не сопоставлено ни одно приложение для выполнения данной операции");
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        Console.Clear();
                        string[] paths = Directory.GetDirectories(p);
                        string[] pathFiles = Directory.GetFiles(p);
                        string[] vse = paths.Concat(pathFiles).ToArray();
                        Console.WriteLine("----------------------Выберите папку или файл--------------------");
                        foreach (string pathi in vse)
                        {
                            var vrema = Directory.GetCreationTime(pathi);
                            var con = Path.GetExtension(pathi);
                            Console.WriteLine("  " + pathi + " Время и дата создания: " + vrema + " Формат: " + con);
                        }
                        Console.WriteLine("------------------------------------------------------------------");
                        int position = Class1.strelka(1, 1, vse.Length);
                        if (position == -1)
                        {
                            return;
                        }
                        ShowPapka(vse[position - 1]);
                    }
                }
                catch (System.UnauthorizedAccessException)
                {
                    Console.Clear();
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!! НЕЛЬЗЯ ТУДА !!!!!!!!!!!!!!!!!");
                    Environment.Exit(0);
                }
            }
        }

    }
}
    

