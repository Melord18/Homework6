namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!"); //1-Vazifa :

            string path = "C:\\Project";

            var directory = Directory.GetDirectories(path);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            else
            {
                Console.Write("This project is already create !!");
            }

            var fileInfo = new FileInfo("C:\\Project\\.gitignore");

            if (fileInfo.Exists)
            {
                fileInfo.Create();
            }
            else
            {
                Console.Write("This file is already create !!");
            }
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }

            //2-Vazifa :

            string[] directories = Directory.GetDirectories("C:\\Project\\", "*bin");
            foreach (string d in directories)
            {
                Console.WriteLine(d);
            }
            string[] directories1 = Directory.GetDirectories("C:\\Project\\", "*bin");
            foreach (string d in directories)
            {
                Console.WriteLine(d);
            }
            //3-vazifa :
            string file1 = "C:\\Project\\Program(7).txt";
            if (!File.Exists(file1))
            {
                File.Create(file1);
            }
            else
            {
                Console.WriteLine("File created before :");
            }
            string[] file = Directory.GetDirectories("C:\\Project", ".txt");

            foreach (string files in file)
            {
                string fullName = Path.GetFileName(files);
                Console.WriteLine(fullName);
            }
        }
    }
}