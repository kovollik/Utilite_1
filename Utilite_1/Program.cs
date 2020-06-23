using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace Utilite_1
{
    public class ReadDirrectoryAndFileName
    {
        public string path;
        public ReadDirrectoryAndFileName(string n) { path = n; }
        public string[] ReadDirectory()         //узнать имена папок в каталоге
        {
            string[] list = Directory.GetDirectories(path);
            int len = path.Length;
            for (int i = 0; i < list.Length; i++)               //выделение имени папок
            {
                list[i] = list[i].Substring(len);
            }
            Array.Sort(list);
            return list;
        }
        public string[] ReadFilesName()                 //узнать имена файлов в каталоге
        {
            string[] list = Directory.GetFiles(path);
            int len = path.Length;
            for (int i = 0; i < list.Length; i++)               //выделение имени папок
            {
                list[i] = list[i].Substring(len);
            }
            Array.Sort(list);
            return list;
        }

    }
    class ShowResultConsole         //вывести результат в консоль
    {
        public string[] list;
        string path;
        public ShowResultConsole(string[] n, string p)
        {
            list = n;
            path = p;
        }
        public void ShowConsole()           //метод для вывода
        {
            Console.WriteLine("Directory " + path + " includes:");
            foreach (string element in list)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine();
        }

        public void ShowInsertDirToConsole()           //метод для вывода списков вложенных папок в консоль
        {
            Console.WriteLine("Directory " + path + " includes:");
            if (list.Length==0) Console.WriteLine("It's empty");                //подпись для пустых папок
            foreach (string element in list)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine();

            for (int i = 0; i < list.Length; i++)
            {
                if (Directory.Exists(path + list[i]))                   
                {
                    ReturnFullArrayList returnFull = new ReturnFullArrayList(path + list[i] + "/");
                    if (returnFull.ReturnList().Length >= 0)
                    {
                        ShowResultConsole showResult = new ShowResultConsole(returnFull.ReturnList(), path + list[i] + "/");
                        showResult.ShowInsertDirToConsole();
                    }
                }
            }

        }
    }

    public class ReturnFullArrayList        //класс для возвращения полного массива
    {
        public string path;
        public ReturnFullArrayList(string p) { path = p; }

        public string[] ReturnList()                        //метод для заполнения нового массива
        {
            ReadDirrectoryAndFileName A = new ReadDirrectoryAndFileName(path);
            string[] dir = A.ReadDirectory();
            string[] fil = A.ReadFilesName();
            string[] list = new string[dir.Length + fil.Length];
            if (dir == null) return fil;
            if (fil == null) return dir;
            return list = dir.Concat(fil).ToArray();
        }
    }

    class Program
    {
        static void Main()
        {
            string newPath = "C:/Files/";
            ReturnFullArrayList returnFull = new ReturnFullArrayList(newPath);
            ShowResultConsole showResult = new ShowResultConsole(returnFull.ReturnList(), newPath);
            showResult.ShowInsertDirToConsole();
        }
    }
}
