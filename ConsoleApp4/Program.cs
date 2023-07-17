using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;

namespace Homework
{
    internal class Program
    {
        static string pazz = "C:\\Users\\hp\\Documents\\PdpC#\\Trenirovka\\Новая папка\\Homework6\\ConsoleApp4\\User1.txt";
      
        static string pazz2 = "C:\\Users\\hp\\Documents\\PdpC#\\Trenirovka\\Новая папка\\Homework6\\ConsoleApp4\\User2.txt";

        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine(" Axrorbek ");
            File.WriteAllText(pazz2, string.Empty);
            File.WriteAllText(pazz, string.Empty);
            while (true)
            {
                Console.Clear();
            bosh:
                Console.Write(" \n 1- Accoun yaratish , 2 - Login , 3 -  Userni ochirish \n : ");
                switch (Console.ReadLine())
                {

                    case "1":

                        CreateUser();
                        break;

                    case "2":

                        Login();
                        break;

                    case "3":

                        DeleteUser();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("invalid option pares any sign");
                        Console.ReadKey();
                        goto bosh;
                }
            }
        }

        public static void CreateUser()
        {
            Console.Clear();
            try
            {
                string name, username, password;
                int phoneNum;
                bool istrue = true;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("________________Create____________________");
                Console.ForegroundColor = ConsoleColor.White;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" Name :");
                name = Console.ReadLine();
                Console.Write(" User Name : ");
                username = Console.ReadLine();
                Console.Write(" Password : ");
                password = Console.ReadLine();
                Console.Write("Phone Number : ");
                phoneNum = Convert.ToInt32(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;

                foreach (User usr in User.Users)
                {
                    if (usr.UserName == username && usr.Password == password)
                    {
                        istrue = false;
                        return;
                    }
                }

                if (istrue)
                {
                    User user = new User(name, username, phoneNum, password);

                    using (StreamWriter writer = File.AppendText(pazz))
                    {
                        writer.WriteLine($" Name : {user.Name}, User Name : {user.UserName}, Password {user.Password}, Number : {user.PhoneNum}");
                        Console.WriteLine(" \n User added ! \n");
                        Thread.Sleep(2000);
                        Console.Clear();
                    }

                    foreach (User usr in User.Users)
                    {
                        if (usr.UserName == username && usr.Password == password)
                        {
                            string userr = $" Name : {usr.Name}, User Name : {usr.UserName}, Password {usr.Password}, Number : {usr.PhoneNum}";

                            using (StreamReader reader = new StreamReader(pazz))
                            {
                                string line;
                                Console.WriteLine("\n Royxat");
                                while ((line = reader.ReadLine()) != null)
                                {
                                    if (line == userr)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\n" + line);
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\n" + line);
                                    }
                                    Console.WriteLine();
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine(" Accaun oldindan mavjud ");
                    Login();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in CreateUser method", ex);
            }
        }

        public static void Login()
        {
            Console.Clear();
            try
            {
                string username, password;
                bool istrue = false;

                if (User.Users.Count == 0)
                {
                    CreateUser();
                    return;
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n________________Login_____________________");
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write(" User name : ");
                username = Console.ReadLine();
                Console.Write("Password :");
                password = Console.ReadLine();

                if (User.Users.Count == 0)
                {
                    CreateUser();
                    return;
                }

                foreach (User usr in User.Users)
                {
                    if (usr.UserName == username && usr.Password == password)
                    {
                        Console.WriteLine(" \n xush kelibsiz \n ");
                        string userr = $" Name : {usr.Name}, User Name : {usr.UserName}, Password {usr.Password}, Number : {usr.PhoneNum}";

                        using (StreamReader reader = new StreamReader(pazz))
                        {
                            string line;
                            Console.WriteLine("\n Royxat \n ");
                            while ((line = reader.ReadLine()) != null)
                            {
                                if (line == userr)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("\n" + line);
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                else
                                {
                                    Console.WriteLine("\n" + line);
                                }
                                Console.WriteLine();
                            }
                        }
                    }
                    else
                    {
                        istrue = true;
                    }
                }

                if (istrue)
                {
                    CreateUser();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Login method", ex);
            }
        }

        public static void DeleteUser()
        {
            Console.Clear();
            try
            {
                using (StreamReader reader = new StreamReader(pazz))
                {
                    string line;

                    if ((line = reader.ReadLine()) == null)
                    {
                        Console.WriteLine("\n Royxat : ");
                        Console.WriteLine(" \n Baza bosh ");
                        Thread.Sleep(2000);
                        reader.Close();
                        return;

                    }

                }
                using (StreamReader reader = new StreamReader(pazz))
                {
                    string line;
                    Console.WriteLine("\n Ro'yxat \n ");
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n" + line);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("O'chirmoqchi bo'lgan hisobingizni foydalanuvchi nomini va parolini kiriting! \n ");
                Console.Write("Foydalanuvchi nomi: ");
                string username = Console.ReadLine();
                Console.Write("Parol: ");
                string password = Console.ReadLine();

                User userToDelete = null;

                foreach (User usr in User.Users)
                {
                    if (usr.UserName == username && usr.Password == password)
                    {
                        userToDelete = usr;
                        break;
                    }
                }

                if (userToDelete != null)
                {
                    User.Users.Remove(userToDelete);

                    using (StreamWriter writer = new StreamWriter(pazz2))
                    {
                        foreach (User usr in User.Users)
                        {
                            writer.WriteLine($" Name: {usr.Name}, User Name: {usr.UserName}, Password: {usr.Password}, Number: {usr.PhoneNum}");
                        }
                    }

                    File.Copy(pazz2, pazz, true);
                    File.WriteAllText(pazz2, string.Empty);

                    Console.WriteLine("\nFoydalanuvchi o'chirildi!\n");
                }
                else
                {
                    Console.WriteLine("Kiritilgan foydalanuvchi nomi yoki parol xato!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in DeleteUser method", ex);
            }
        }
    }

    class User
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public int PhoneNum { get; set; }
        public string Password { get; set; }

        public static List<User> Users { get; set; } = new List<User>();

        public User()
        {

        }

        public User(string name, string username, int phonenum, string password)
        {
            Name = name;
            UserName = username;
            PhoneNum = phonenum;
            Password = password;
            Users.Add(this);
        }
    }
}
