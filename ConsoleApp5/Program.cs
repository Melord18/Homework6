using System;
using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp5
{
    internal class Program
    {
        static string path = "C:\\Users\\hp\\Documents\\PdpC#\\Trenirovka\\Новая папка\\Homework6\\ConsoleApp5\\UseR.txt";
        static string path2 = "C:\\Users\\hp\\Documents\\PdpC#\\Trenirovka\\Новая папка\\Homework6\\ConsoleApp5\\UseR2.txt";
        

        static void Main(string[] args)
        { /*if (!File.Exists(path)||File.Exists(path2) )
            {
                File.Create(path);
                File.Create(path2);
            }
            else
            {
                Console.WriteLine("File already created !!!");
            }*/
            Console.Clear();
            File.WriteAllText(path,string.Empty);
            File.WriteAllText(path2, string.Empty);
            while (true)
            {
                Console.WriteLine("1.SignUp :");
                Console.WriteLine("2.Login :");
                Console.WriteLine("3.Exit :");
                Console.WriteLine("Enter a number for which you want doing :");

                

                switch (Console.ReadLine())
                {
                    case "1": SignUp();
                        break;
                    case "2": Login();    
                        break;
                    case "3": DeleteUser();
                        break;
                    default:Console.Clear();
                            Console.WriteLine("Please choose numbers which have in console :"); break;
                            Console.ReadKey();
                }
            
                Console.WriteLine();
               

            }
        }
    } 
    public static void SignUp()
    {
        try
        {
            string name, username, password;
            int phoneNum;
            bool istrue = true;
            Console.WriteLine("________________SignUp____________________");
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

    }
    

    class User
    {
        public string FullName {get; set;}
        public string UserName { get; set;}
        public int PhoneNum { get; set;}
        public string Password { get; set;}
        public static List<User> Users { get; set;} = new List<User>(); 

        public User()
        {

        }
        public User(string fullname,string username,int phonenum,string password)
        {
            FullName = fullname;    
            UserName = username;    
            PhoneNum = phonenum;    
            Password = password;
            Users.Add(this);
        }
    }
}