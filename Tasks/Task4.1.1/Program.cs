using System;
using System.Collections.Generic;
using System.IO;

namespace Task4._1._1
{
    class Program
    {
        static DirectoryInfo loggingDirectory;//Директория в которой будут храниться файлы-логи
        static string today = "";//Используется для создания папок с названием текущего дня, месяца и года
        static DirectoryInfo watchDirectory;//Директория за которой будем следить
        [STAThread]
        static void Main(string[] args)
        {
            //При каждом изменении любого файла создаются 2 папки(если их нет):
            //1. Папка с текущей датой
            //2. Папка с текущим временем
            //И после этого все файлы в выбранной для слежения папки помещаются туда
            //Например, следим за папкой с полным путем C:\ExampleDirectory\
            //Имея файл file.txt и изменяя его 02.08.2020 в 00:00:00
            //Он(и все остальные файлы, которые лежат в это время в папке для слежки) поместится в папку
            //с полным путем C:\Logging\02.08.2020\00.00.00\

            today = "\\" + DateTime.Now.Day.ToString() + "." + DateTime.Now.Month.ToString() + "." + DateTime.Now.Year.ToString();
            loggingDirectory = new DirectoryInfo(@"C:\Users\Ivan\Desktop\Logging");
            watchDirectory = new DirectoryInfo(@"C:\Users\Ivan\Desktop\Example");

            Console.WriteLine("Выберите режим: \n1. Наблюдение\n2. Откат изменений");
            int changes = 0;
            while (!int.TryParse(Console.ReadLine(), out changes) || changes != 1 && changes != 2);

            if (changes == 1)
            {
                FileSystemWatcher watcher = new FileSystemWatcher(watchDirectory.FullName);

                watcher.NotifyFilter = NotifyFilters.LastWrite |
                                       NotifyFilters.FileName |
                                       NotifyFilters.Size |
                                       NotifyFilters.Attributes;
                //Будем следить за изменениями последней записи в файл, имени файла, размера и атрибутов

                watcher.Filter = "*.txt";//Отслеживаем, соответственно, текстовые файлы

                watcher.Changed += OnChanged;//На любые изменения файла подписываем функцию, которая логгирует изменения
                watcher.Created += OnChanged;
                watcher.Deleted += OnChanged;
                watcher.Renamed += OnChanged;

                watcher.EnableRaisingEvents = true;//Запускаем

                Directory.CreateDirectory(loggingDirectory.FullName + today);//В папке логгирования создаем подпапку с сегодняшней датой, если таковой нет

                Console.WriteLine("Для выхода из приложения нажмите q");
                while (Console.Read() != 'q') ;
            }
            else
            {
                Console.WriteLine("Выберите дату для отката: ");
                for(int i = 0; i < loggingDirectory.GetDirectories().Length; i++)//Выводим все прямые подпапки нашей папки логгирования, то есть папки, в названии которых даты
                    Console.WriteLine((i + 1).ToString() + ". " + loggingDirectory.GetDirectories()[i]);

                int recoveringDate = 0;
                while (!int.TryParse(Console.ReadLine(), out recoveringDate));

                Console.WriteLine("Выберите время для отката: ");//Выводим все подпапки выбранной даты, то есть те, в названии которых время
                for (int i = 0; i < loggingDirectory.GetDirectories()[recoveringDate - 1].GetDirectories().Length; i++)
                    Console.WriteLine((i + 1).ToString() + ". " + loggingDirectory.GetDirectories()[recoveringDate - 1].GetDirectories()[i]);

                int recoveringTime = 0;
                while (!int.TryParse(Console.ReadLine(), out recoveringTime));

                //Восстанавливаем папку с выбранной датой и выбранным временем
                Recovery(loggingDirectory.GetDirectories()[recoveringDate - 1].GetDirectories()[recoveringTime - 1].FullName);
            }
        }

        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            //Создаем новую директорию с набором файлов для будущего бэкапа
            DirectoryInfo newSet = new DirectoryInfo(loggingDirectory + today + "\\" + DateTime.Now.Hour + "." + DateTime.Now.Minute + "." + DateTime.Now.Second);
            newSet.Create();

            //Помещаем в ранее созданную директорию все файлы, которые сейчас находятся в папке для слежки
            FileInfo[] loggingFiles = watchDirectory.GetFiles();

            for (int i = 0; i < loggingFiles.Length; i++)
                loggingFiles[i].CopyTo(newSet.FullName + "\\" + loggingFiles[i].Name, true);

            //Выводим полный путь до измененного файла и тип изменения
            Console.WriteLine(e.FullPath + " " + e.ChangeType);
        }

        private static void Recovery(string recoveringFolder)
        {
            //Получаем все файлы в выбранной для восстановления папки
            FileInfo[] recoveringFiles = new DirectoryInfo(recoveringFolder).GetFiles();

            for (int i = 0; i < recoveringFiles.Length; i++)//Копируем их в папку для отслеживания
                recoveringFiles[i].CopyTo(watchDirectory.FullName + "\\" + recoveringFiles[i].Name, true);
        }
    }
}
